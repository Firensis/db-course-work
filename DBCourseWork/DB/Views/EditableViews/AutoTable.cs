using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.SqlBuilders;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.DB.Views.Structures;
using DBCourseWork.Forms.Interface.Fields;

namespace DBCourseWork.DB.Views.EditableViews
{
    class AutoTable : EditableView
    {
        public override string Name => "Автомобиль";

        public override Dictionary<string, Field> GetDeleteFields()
        {
            ComboBoxField combo = new ComboBoxField(keyValueData.Keys, "Номер госрегистрации");
            combo.ResetSelectedItem();

            return new Dictionary<string, Field>
            {
                { "register_number",  combo}
            };
        }

        public override Dictionary<string, Field> GetInsertFields()
        {
            return new Dictionary<string, Field>
            {
                { "register_number", new TextField("Номер госрегистрации") },
                { "mark", new TextField("Марка") },
                { "year", new TextField("Год выпуска") },
                { "creator", new TextField("Изготовитель") }
            };
        }

        public override Dictionary<string, Field> GetUpdateFields()
        {
            ComboBoxField primary = new ComboBoxField(keyValueData.Keys, "Номер госрегистрации");
            TextField newRegNum = new TextField("Новый номер госрегистрации");
            TextField mark = new TextField("Марка");
            TextField year = new TextField("Год выпуска");
            TextField creator = new TextField("Изготовитель");

            primary.SelectedValueChanged += (string newPrimary) =>
            {
                object[] newCurrent = keyValueData[newPrimary];
                newRegNum.SetValue(newPrimary);
                mark.SetValue(newCurrent[1]);
                year.SetValue(newCurrent[2]);
                creator.SetValue(newCurrent[3]);
            };

            primary.ResetSelectedItem();

            return new Dictionary<string, Field>
            {
                { "register_number", primary },
                { "new_register_number", newRegNum },
                { "mark", mark },
                { "year", year },
                { "creator", creator },
            };
        }

        public override string[] GetTableHeader()
        {
            return new string[]
            {
                "Номер госрегистрации",
                "Марка",
                "Год выпуска",
                "Изготовитель"
            };
        }

        protected override string GetInsertSql(Dictionary<string, Field> values)
        {
            InsertSqlBuilder insertBuilder = Program.Container.GetInsertSqlBuilder();

            return insertBuilder
                .InsertTo("Автомобиль")
                .SetValue("Номер_Госрегистрации", values["register_number"].Value)
                .SetValue("Марка", values["mark"].Value)
                .SetValue("Год_Выпуска", values["year"].Value)
                .SetValue("Изготовитель", values["creator"].Value)
                .GetResult();
        }

        protected override string GetSelectSql(Filter filter = null)
        {
            string query = "SELECT Номер_Госрегистрации, Марка, Год_Выпуска, Изготовитель FROM Автомобиль";

            if (filter != null)
            {
                query += $@" WHERE ""{filter.SqlFieldName}"" = '{filter.Value}'";
            }

            query += " ORDER BY Номер_Госрегистрации";

            return query;
        }

        protected override string GetUpdateSql(Dictionary<string, Field> values)
        {
            UpdateSqlBuilder updateBuilder = Program.Container.GetUpdateSqlBuilder();

            return updateBuilder
                .Update("Автомобиль", $"\"Номер_Госрегистрации\" = '{values["register_number"]}'")
                .Set("Марка", values["mark"].Value)
                .Set("Номер_Госрегистрации", values["new_register_number"].Value)
                .Set("Год_Выпуска", values["year"].Value)
                .Set("Изготовитель", values["creator"].Value)
                .GetResult();
            ;
        }

        protected override string GetDeleteSql(Dictionary<string, Field> values)
        {
            return $@"DELETE FROM Автомобиль WHERE ""Номер_Госрегистрации"" = '{values["register_number"]}'";
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
                    Title = "Марка",
                    SqlFieldName = "Марка"
                },
                new Filter
                {
                    Title = "Год выпуска",
                    SqlFieldName = "Год_Выпуска"
                },
                new Filter
                {
                    Title = "Изготовитель",
                    SqlFieldName = "Изготовитель"
                }
            };
        }
    }
}
