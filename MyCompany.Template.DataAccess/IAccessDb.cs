using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Template.DataAccess
{
    public interface IAccessDb
    {
        // Common properties
        string ConnectionString { get; set; }
        bool IsConnected { get; }

        // Common methods
        
        void Connect();
        void Disconnect();
        void ExecuteQuery(string query);
        DataTable ExecuteQueryWithResult(string query);
        void LoadRecords<T>(string tableName, Dictionary<string, object> values);
        void InsertRecords<T>(string tableName, Dictionary<string, object> values);
        void UpdateRecord(string tableName, Dictionary<string, object> values, string condition);
        void DeleteRecord(string tableName, string condition);
    }
}
