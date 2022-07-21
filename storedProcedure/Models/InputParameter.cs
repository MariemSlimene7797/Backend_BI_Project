using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storedProcedure.Models
{
    public class InputParameter
    {
        public InputParameter(string name, dynamic value)
        {
            Name = name;
            Type = GetType(value);
            Value = value;
        }

        private SqlDbType GetType(dynamic value)
        {
            if (value is int)
            {
                return SqlDbType.Int;

            }
            if (value is DateTime)
            {
                return SqlDbType.DateTime;
            }
            if (value is Boolean)
            {
                return SqlDbType.Bit;
            }
            if (value is Decimal)
            {
                return SqlDbType.Decimal;
            }
            if (value is float)
            {
                return SqlDbType.Float;
            }
            return SqlDbType.VarChar;
            
        }

        public string Name { get; set; }
        public SqlDbType Type { get; set; }
        public dynamic Value { get; set; }
    }
}
