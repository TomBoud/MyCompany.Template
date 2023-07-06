using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using MyCompany.Template.Abstraction;

namespace MyCompany.Template.AddIn.Models
{
    public class RevitElement : IElement
    {
        private readonly Element _element;

        public RevitElement(Element elemant)
        {
            _element = elemant;
        }

        #region Properties
        public string Name { get { return _element.Name; } set { Name = value; } }
        public string LevelName { get { return GetLevelName(); } set { LevelName = value; } }
        public string CategoryName { get { return _element.Category.Name; } set { CategoryName = value; } }
        public string DocumentName { get { return _element.Document.Title; } set { DocumentName = value; } }
        
        public int Id { get { return _element.Id.IntegerValue; } set { Id = value; } }
        public int LevelId { get { return _element.LevelId.IntegerValue; } set { Id = value; } }
        #endregion

        #region Methods
        private string GetLevelName()
        {
            var level = _element.Document.GetElement(_element.LevelId) as Level;
            
            if(level is null)
            {
                return string.Empty;
            }
            else
            {
                return level.Name;
            }
        }
        #endregion
    }
}
