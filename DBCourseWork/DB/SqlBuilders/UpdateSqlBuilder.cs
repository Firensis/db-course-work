using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.SqlBuilders
{
    class UpdateSqlBuilder
    {
        string sql;
        List<string> setParts;
        protected Dictionary<string, Field> formFields;

        public UpdateSqlBuilder Update(string tableName, string where)
        {
            setParts = new List<string>();
            sql = $"UPDATE \"{tableName}\" SET #DEFINITIONS# WHERE {where};";

            return this;
        }

        public UpdateSqlBuilder FromFields(Dictionary<string, Field> fields)
        {
            formFields = fields;

            return this;
        }

        public UpdateSqlBuilder Set(string column, string value, bool subquery = false)
        {
            string valToSet = subquery ? $"({value})" : $"'{value}'";
            string res = $"\"{column}\" = {valToSet}";
            setParts.Add(res);

            return this;
        }

        public UpdateSqlBuilder SetFromFields(string column, string fieldKey)
        {
            return Set(column, formFields[fieldKey].Value);
        }

        public string GetResult()
        {
            return sql.Replace("#DEFINITIONS#", setParts.Implode(", "));
        }
    }
}
