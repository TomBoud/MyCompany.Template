using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Template.Abstraction;

namespace MyCompany.Template.AddIn.Models
{
    public class RevitDocument : IDocumnet
    {
        private readonly Document _document;

        public RevitDocument(Document document)
        {
            _document = document;
        }

        #region Properties
        public string Title { get { return _document.Title; } set { Title = value; } }
        #endregion
    }
}
