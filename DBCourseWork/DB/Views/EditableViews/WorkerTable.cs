using DBCourseWork.DB.Views.FieldsBuilder;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.Views.Structures;

namespace DBCourseWork.DB.Views.EditableViews
{
    class WorkerTable : EditableView
    {
        public override string Name => "Сотрудник";
        readonly Column pasport = new Column { Code = "pasport", Title = "Паспорт" };
        readonly Column surname = new Column { Code = "surname", Title = "Фамилия" };
        readonly Column name = new Column { Code = "name", Title = "Имя" };
        readonly Column secondName = new Column { Code = "second_name", Title = "Отчество" };

        public override Dictionary<string, Field> GetDeleteFields()
        {
            ComboBoxField combo = new ComboBoxField(keyValueData.Keys, pasport.Title);
            combo.ResetSelectedItem();

            return new Dictionary<string, Field>
            {
                { pasport.Code,  combo}
            };
        }

        public override Dictionary<string, Field> GetInsertFields()
        {
            return new Dictionary<string, Field>
            {
                { pasport.Code, new TextField(pasport.Title) },
                { surname.Code, new TextField(surname.Title) },
                { name.Code, new TextField(name.Title) },
                { secondName.Code, new TextField(secondName.Title) }
            };
        }

        public override string[] GetTableHeader()
        {
            return new string[]
            {
                "Паспорт",
                "Фамилия",
                "Имя",
                "Отчество"
            };
        }

        public override Dictionary<string, Field> GetUpdateFields()
        {
            var updateFieldsBuilder = new UpdateFieldsBuilder();

            return updateFieldsBuilder
                .BuildNew(keyValueData)
                .SetPrimary(pasport.Code, pasport.Title)
                .AddTextField(surname.Code, new TextField(surname.Title), 1)
                .AddTextField(name.Code, new TextField(name.Title), 2)
                .AddTextField(secondName.Code, new TextField(secondName.Title), 3)
                .GetResult();
        }

        protected override string GetDeleteSql(Dictionary<string, Field> values)
        {
            return $@"DELETE FROM Сотрудник WHERE ""Паспорт"" = '{values[pasport.Code]}'";
        }

        protected override string GetInsertSql(Dictionary<string, Field> values)
        {
            return $@"
                INSERT INTO Сотрудник VALUES
                ('{values[pasport.Code]}', '{values[surname.Code]}', '{values[name.Code]}', '{values[secondName.Code]}')
            ";
        }

        protected override string GetSelectSql(Filter filter = null)
        {
            string query = "SELECT * FROM Сотрудник";

            if (filter != null)
            {
                query += $@" WHERE ""{filter.SqlFieldName}"" = '{filter.Value}'";
            }

            query += " ORDER BY Паспорт";

            return query;
        }

        protected override string GetUpdateSql(Dictionary<string, Field> values)
        {
            var updateBuilder = Program.Container.GetUpdateSqlBuilder();

            return updateBuilder
                .Update("Сотрудник", $"\"Паспорт\" = '{values[pasport.Code]}'")
                .FromFields(values)
                .SetFromFields("Паспорт", pasport.Code)
                .SetFromFields("Фамилия", surname.Code)
                .SetFromFields("Имя", name.Code)
                .SetFromFields("Отчество", secondName.Code)
                .GetResult();
        }

        public override Filter[] GetAviableFilters()
        {
            return new Filter[]
            {
                new Filter
                {
                    Title = "Паспорт",
                    SqlFieldName = "Паспорт"
                },
                new Filter
                {
                    Title = "Фамилия",
                    SqlFieldName = "Фамилия"
                },
                new Filter
                {
                    Title = "Имя",
                    SqlFieldName = "Имя"
                },
                new Filter
                {
                    Title = "Отчество",
                    SqlFieldName = "Отчество"
                }
            };
        }
    }
}
