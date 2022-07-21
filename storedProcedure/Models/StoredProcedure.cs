using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace storedProcedure.Models
{
    public class StoredProcedure
    {
        private SqlCommand _sqlCommand;
        private List<InputParameter> _parameters;
        private DataTable _data;
        public StoredProcedure(string name, string connectionString)
        {
            var sqlConnection = new SqlConnection(connectionString);
            _sqlCommand = new SqlCommand(name, sqlConnection);
            _parameters = new List<InputParameter>();
            _parameters.Add(new InputParameter("LanguageKey", "FR"));
            _data = new DataTable();
            
        }

        public void InitializeConnection()
        {

            foreach (var item in _parameters)
            {
                _sqlCommand.Parameters.Add(new SqlParameter($"@{item.Name}", item.Type) { Direction = ParameterDirection.Input, Value = item.Value });
            }

            _sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public void AddInputParameter(InputParameter inputparameter)
        {
            _parameters.Add(inputparameter);
        }

        private DataTable GetData()
        {
            InitializeConnection();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = _sqlCommand;

            da.Fill(_data);

            return _data;

        }
       /* private DataTable PostData()
        {
            InitializeConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            InputParameter parameter1 = new InputParameter("x", 9);
            InputParameter parameter2 = new InputParameter("y", 1.2);
            InputParameter parameter3 = new InputParameter("z", 3);
            da.InsertCommand = _sqlCommand;

            da.Fill(_data);
            return _data;
        }*/
        public string GetJsonData()
        {
            GetData();

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(_data);
            return JSONString;
        }
        
    }
}
