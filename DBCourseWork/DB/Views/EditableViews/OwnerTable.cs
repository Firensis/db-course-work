using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.DB.Views.Structures;
using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Views.EditableViews
{
    class OwnerTable : EditableView
    {
        public override string Name => "Владелец";

        public override string[] GetTableHeader()
        {
            return new string[]
            {
                "Номер госрегистрации автомобиля",
                "Фамилия",
                "Имя",
                "Отчество",
                "Адрес"
            };
        }

        public override Dictionary<string, Field> GetDeleteFields()
        {
            ComboBoxField combo = new ComboBoxField(keyValueData.Keys, "Номер госрегистрации автомобиля");
            combo.ResetSelectedItem();

            return new Dictionary<string, Field>
            {
                { "auto_register_number",  combo}
            };
        }

        public override Dictionary<string, Field> GetInsertFields()
        {
            return new Dictionary<string, Field>
            {
                { "auto_register_number", new TextField("Номер госрегистрации") },
                { "surname", new TextField("Фамилия") },
                { "name", new TextField("Имя") },
                { "second_name", new TextField("Отчество") },
                { "address", new TextField("Адрес") }
            };
        }

        public override Dictionary<string, Field> GetUpdateFields()
        {
            ComboBoxField primary = new ComboBoxField(keyValueData.Keys, "Номер госрегистрации автомобиля");
            TextField surname = new TextField("Фамилия");
            TextField name = new TextField("Имя");
            TextField second_name = new TextField("Отчество");
            TextField address = new TextField("Адрес");

            primary.SelectedValueChanged += (string newPrimary) =>
            {
                object[] newCurrent = keyValueData[newPrimary];

                surname.SetValue(newCurrent[1]);
                name.SetValue(newCurrent[2]);
                second_name.SetValue(newCurrent[3]);
                address.SetValue(newCurrent[4]);
            };

            primary.ResetSelectedItem();

            return new Dictionary<string, Field>
            {
                { "auto_register_number", primary },
                { "surname", surname },
                { "name", name },
                { "second_name", second_name },
                { "address", address }
            };
        }

        protected override string GetDeleteSql(Dictionary<string, Field> values)
        {
            return $@"DELETE FROM ""Владелец"" WHERE 
            ""Id_Автомобиля"" = (SELECT ""Id"" FROM Автомобиль WHERE ""Номер_Госрегистрации"" = '{values["auto_register_number"]}')";
        }

        protected override string GetInsertSql(Dictionary<string, Field> values)
        {
            var insertBuilder = Program.Container.GetInsertSqlBuilder();
            string idSubquery = $"SELECT \"Id\" FROM Автомобиль WHERE Номер_Госрегистрации = '{values["auto_register_number"]}'";

            return insertBuilder
                .InsertTo("Владелец")
                .SetValue("Id_Автомобиля", idSubquery, true)
                .SetValue("Фамилия", values["surname"].Value)
                .SetValue("Имя", values["name"].Value)
                .SetValue("Отчество", values["second_name"].Value)
                .SetValue("Адрес", values["address"].Value)
                .GetResult();
        }

        protected override string GetSelectSql(Filter filter = null)
        {
            string query = "SELECT Номер_Госрегистрации, Фамилия, Имя, Отчество, Адрес " +
                "FROM Владелец JOIN Автомобиль ON (Владелец.\"Id_Автомобиля\" = Автомобиль.\"Id\")";

            if (filter != null)
            {
                query += $@" WHERE ""{filter.SqlFieldName}"" = '{filter.Value}'";
            }

            query += " ORDER BY Номер_Госрегистрации";

            return query;
        }

        protected override string GetUpdateSql(Dictionary<string, Field> values)
        {
            var updateBuilder = Program.Container.GetUpdateSqlBuilder();
            string updateWhere = 
                $"\"Id_Автомобиля\" = (SELECT \"Id\" FROM \"Автомобиль\" WHERE \"Номер_Госрегистрации\" = '{values["auto_register_number"]}')";

            return updateBuilder
                .Update("Владелец", updateWhere)
                .Set("Фамилия", values["surname"].Value)
                .Set("Имя", values["name"].Value)
                .Set("Отчество", values["second_name"].Value)
                .Set("Адрес", values["address"].Value)
                .GetResult();
        }

        public override Filter[] GetAviableFilters()
        {
            return new Filter[]
            {
                new Filter
                {
                    Title = "Номер госрегистрации",
                    SqlFieldName = "Номер_Госрегистрации"
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
                },
                new Filter
                {
                    Title = "Адрес",
                    SqlFieldName = "Адрес"
                }
            };
        }
    }
}
