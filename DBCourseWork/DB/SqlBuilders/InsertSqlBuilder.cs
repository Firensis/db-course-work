using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.SqlBuilders
{
    class InsertSqlBuilder
    {
        protected string sql = "";
        protected List<string> fields;
        protected List<string> fieldsValues;
        protected Dictionary<string, Field> formFields;

        public InsertSqlBuilder FromFields(Dictionary<string, Field> formFields)
        {
            this.formFields = formFields;

            return this;
        }

        public InsertSqlBuilder InsertTo(string tableName)
        {
            sql = "";
            fields = new List<string>();
            fieldsValues = new List<string>();

            sql = $@"INSERT INTO ""{tableName}"" (#FIELDS#) VALUES(#VALUES#);";

            return this;
        }

        public InsertSqlBuilder SetValue(string column, string value, bool subQuery = false)
        {
            fields.Add($"\"{column}\"");
            string valToAdd = subQuery ? $"({value})"  : $"'{value}'";
            fieldsValues.Add(valToAdd);

            return this;
        }

        public InsertSqlBuilder SetFromFields(string column, string fieldKey)
        {
            return SetValue(column, formFields[fieldKey].Value);
        }

        public string GetResult()
        {
            string res = sql.Replace("#FIELDS#", fields.Implode(", "));

            return res.Replace("#VALUES#", fieldsValues.Implode(", "));
        }
    }
}
