using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

using MyCompany.Template.AddIn.Models;
using MyCompany.Template.Abstraction;
using MyCompany.Template.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace MyCompany.Template.AddIn.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class RevitCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Reffrence to revit application objects
            var app = commandData.Application.Application;
            var doc = commandData.Application.ActiveUIDocument.Document;

            //Absstract revit object for the UI
            IDocumnet idoc = new RevitDocument(doc);
            var userInterface = new FormRevitCmd(idoc);
            userInterface.ShowDialog();

            //Get user interaction result
            var userPrefernces = GetAllPropertiesAndValues(userInterface);

            //Execute command logic
            var logicOutput = ExecuteCommandLogic(doc,userPrefernces as IList<(PropertyInfo, object)>);

            //Return feedback to the user
            MessageBox.Show(logicOutput.ToString());

            return Result.Succeeded;
        }

        private object GetAllPropertiesAndValues(System.Windows.Forms.Form form)
        {
            PropertyInfo[] properties = form.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var result = new List<(PropertyInfo, object)>();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(form);
                result.Add((property, value));
            }
            return result;
        }
        private object ExecuteCommandLogic(Document doc, IList<(PropertyInfo, object)> userPrefernces)
        {
            string userInput = userPrefernces.First().Item1.Name;
            var collecotrElemetns = new FilteredElementCollector(doc)
               .OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(Wall)).ToElements();

            var revitElements = new List<RevitElement>();
            collecotrElemetns.ToList().ForEach(element =>
            {
                if (element.Name.Contains(userInput))
                {
                    revitElements.Add(new RevitElement(element));
                }
            });


            return null;
        }
    }
}
