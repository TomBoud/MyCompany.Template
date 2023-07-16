using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MyCompany.Template.Abstractions;

namespace MyCompany.Template.DataAccess.SQLite
{
    public class SQLiteDataAccess : IAccessDb
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsConnected => throw new NotImplementedException();

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(string tableName, string condition)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteQueryWithResult(string query)
        {
            throw new NotImplementedException();
        }

        public void InsertRecords<T>(string tableName, Dictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        public void LoadRecords<T>(string tableName, Dictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecord(string tableName, Dictionary<string, object> values, string condition)
        {
            throw new NotImplementedException();
        }
    }
}
