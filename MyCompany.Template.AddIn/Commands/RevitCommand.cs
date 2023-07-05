using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using MyCompany.Template.AddIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Template.AddIn.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class RevitCommand : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var collecotrElemetns = new FilteredElementCollector(commandData.Application.ActiveUIDocument.Document)
                .OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(Wall)).ToElements();

            var revitElements = new List<RevitElement>();
            collecotrElemetns.ToList().ForEach(element => { revitElements.Add(new RevitElement(element)); });

           

            return Result.Succeeded;
        }
    }
}
