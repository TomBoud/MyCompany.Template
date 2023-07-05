using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Template.Abstraction.Interfaces
{
    public interface IElement
    {
        string Name { get; set; }
        string LevelName { get; set; }
        string DocumentName { get; set; }
        string CategoryName { get; set; }

        int Id { get; set; }
        int LevelId { get; set; }

    }
}
