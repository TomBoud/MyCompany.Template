using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Template.DataAccess
{
    public interface IAccessApi
    {
        // Common properties
        string BaseUrl { get; set; }
        string ApiKey { get; set; }

        // Common methods
        string Get(string endpoint);
        string Post(string endpoint, string data);
        string Put(string endpoint, string data);
        string Delete(string endpoint);
    }
}
