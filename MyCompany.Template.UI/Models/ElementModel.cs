using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MyCompany.Template.Abstractions;

namespace MyCompany.Template.UI.Models
{
    public class ElementModel : IElement
    {
        // Private Fields
        private long id;
        private string name;
        private string levelName;
        private string documentName;
        private string categoryName;
        private long elementId;
        private long levelId;

        // Properties - Validation
        [DisplayName("Object ID")]
        public long Id 
        { get => id; set => id = value; }

        [DisplayName("Object Name")]
        [Required(ErrorMessage = "Element name is required")]
        public string Name 
        { get => name; set => name = value; }

        [DisplayName("Object Level Name")]
        public string LevelName 
        { get => levelName; set => levelName = value; }

        [DisplayName("Element Id")]
        [Required(ErrorMessage = "Element id is required")]
        public long ElementId 
        { get => elementId; set => elementId = value; }

        [DisplayName("Object Level Id")]
        public long LevelId 
        { get => levelId; set => levelId = value; }

        [DisplayName("RVT Model Name")]
        [Required(ErrorMessage = "Documnet Name is required")]
        public string DocumentName 
        { get => documentName; set => documentName = value; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName 
        { get => categoryName; set => categoryName = value; }
       
    }
}
