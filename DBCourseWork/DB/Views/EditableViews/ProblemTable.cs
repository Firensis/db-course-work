using DBCourseWork.DB.Views.FieldsBuilder;
using DBCourseWork.DB.UserSystem;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.Views.Structures;
using DBCourseWork.DB.Views.EditableViews.Exceptions;

namespace DBCourseWork.DB.Views.EditableViews
{
    class ProblemTable : EditableView
    {
        public override string Name => "Неисправность";

        public IEnumerable<string> GetFixedAutoWithOwner()
        {
            string sql = @"
                SELECT DISTINCT ""Номер_Госрегистрации"" 
                FROM ""Неисправность"" 
                JOIN ""Автомобиль"" ON (""Неисправность"".""Id_Автомобиля"" = ""Автомобиль"".""Id"")
                ORDER BY ""Номер_Госрегистрации""
            ";

            LoadData(sql);
            List<string> result = new List<string>();

            foreach (object[] row in data)
            {
                result.Add(row[0].ToString());
            }

            return result;
        }

        public override Filter[] GetAviableFilters()
        {
            return new Filter[]
            {
                new Filter
                {
                    Title = "Id",
                    SqlFieldName = "\"Неисправность\".\"Id\""
                },
                new Filter
                {
                    Title = "Номер госрегистрации автомобиля",
                    SqlFieldName = "Номер_Госрегистрации"
                },
                new Filter
                {
                    Title = "Марка автомобиля",
                    SqlFieldName = "\"Автомобиль\".\"Марка\""
                },
                new Filter
                {
                    Title = "Тип неисправности",
                    SqlFieldName = "Тип_Неисправности"
                },
                new Filter
                {
                    Title = "Паспорт сотрудника",
                    SqlFieldName = "Паспорт_Сотрудника"
                },
                new Filter
                {
                    Title = "Время ремонта",
                    SqlFieldName = "Время_Ремонта"
                },
                new Filter
                {
                    Title = "ФИО владельца",
                    SqlFieldName = "FIO"
                }
            };
        }

        public override Dictionary<string, Field> GetDeleteFields()
        {
            if (keyValueData.Count == 0)
            {
                throw new NoRowsToEditException();
            }

            User user = Program.Container.GetCurrentUser();
            
            IEnumerable<string> comboValues = user.Role.Name == "worker" ? GetCurrentUserKeys() : keyValueData.Keys;

            if (comboValues.Count() == 0)
            {
                throw new NoRowsToEditException();
            }

            ComboBoxField combo = new ComboBoxField(comboValues, "Id");
            combo.ResetSelectedItem();

            return new Dictionary<string, Field>
            {
                { "id",  combo}
            };
        }

        public override Dictionary<string, Field> GetInsertFields()
        {
            User user = Program.Container.GetCurrentUser();
            
            TextField workerField = new TextField("Паспорт_Сотрудника", user.UserId)
            {
                PreventSet = user.Role.Name == "worker"
            };

            return new Dictionary<string, Field>
            {
                { "auto_registration_number", new TextField("Номер госрегистрации") },
                { "type", new TextField("Тип_Неисправности") },
                { "worker", workerField },
                { "time", new TextField("Время_Ремонта") }
            };
        }

        public override string[] GetTableHeader()
        {
            return new string[]
            {
                "Id",
                "Номер госрегистрации автомобиля",
                "Тип неисправности",
                "Паспорт сотрудника",
                "Время ремонта"
            };
        }

        public override Dictionary<string, Field> GetUpdateFields()
        {
            if (keyValueData.Count == 0)
            {
                throw new NoRowsToEditException();
            }

            UpdateFieldsBuilder builder = new UpdateFieldsBuilder();
            
            builder.BuildNew(keyValueData);
            User user = Program.Container.GetCurrentUser();
            bool isWorker = user.Role.Name == "worker";

            if (isWorker)
            {
                var keys = GetCurrentUserKeys();
                if (keys.Count() == 0)
                {
                    throw new NoRowsToEditException();
                }
                builder.SetPrimary("id", keys, "Id неисправности");
            }
            else
            {
                builder.SetPrimary("id", "Id неисправности");
            }
            
            builder.AddTextField("auto_registration_number", new TextField("Номер госрегистрации автомобиля"), 1);
            builder.AddTextField("type", new TextField("Тип неисправности"), 2);
            TextField pasport = new TextField("Паспорт сотрудника");

            if (isWorker)
            {
                pasport.PreventSet = true;
            }

            builder.AddTextField("worker", pasport, 3);
            builder.AddTextField("time", new TextField("Время ремонта"), 4);

            return builder.GetResult();
        }

        protected IEnumerable<string> GetCurrentUserKeys()
        {
            User user = Program.Container.GetCurrentUser();

            return keyValueData
                    .Where(
                        (pair) => pair.Value[3].ToString() == user.UserId
                    )
                    .Select((pair) => pair.Key);
        }

        protected override string GetDeleteSql(Dictionary<string, Field> values)
        {
            return $@"
                DELETE FROM Неисправность WHERE ""Id"" = '{values["id"]}'
            ";
        }

        protected override string GetInsertSql(Dictionary<string, Field> values)
        {
            var insertBuilder = Program.Container.GetInsertSqlBuilder();
            string subquery = $@"SELECT ""Id"" FROM Автомобиль WHERE ""Номер_Госрегистрации"" = '{values["auto_registration_number"]}'";
            
            return insertBuilder
                .FromFields(values)
                .InsertTo("Неисправность")
                .SetValue("Id_Автомобиля", subquery, true)
                .SetFromFields("Тип_Неисправности", "type")
                .SetFromFields("Паспорт_Сотрудника","worker")
                .SetFromFields("Время_Ремонта", "time")
                .GetResult();
        }

        protected override string GetSelectSql(Filter filter = null)
        {
            string query = "SELECT Неисправность.\"Id\", Номер_Госрегистрации, Тип_Неисправности, Паспорт_Сотрудника, Время_Ремонта " +
                "FROM Неисправность JOIN Автомобиль ON (Неисправность.\"Id_Автомобиля\" = Автомобиль.\"Id\")";

            if (filter != null)
            {
                query += BuildFilterCondition(filter);
            }

            query += " ORDER BY Неисправность.\"Id\"";

            return query;
        }

        protected string BuildFilterCondition(Filter filter)
        {
            string sql;

            if (filter.SqlFieldName == "FIO")
            {
                sql = $@" LEFT JOIN ""Владелец"" on (""Владелец"".""Id_Автомобиля"" = ""Автомобиль"".""Id"")
        WHERE ""Владелец"".""Фамилия"" || ' ' || ""Владелец"".""Имя"" || ' ' || ""Владелец"".""Отчество"" = '{filter.Value}'
";
            }
            else
            {
                sql = $@" WHERE {filter.SqlFieldName} = '{filter.Value}'";
            }

            return sql;
        }

        protected override string GetUpdateSql(Dictionary<string, Field> values)
        {
            var updateBuilder = Program.Container.GetUpdateSqlBuilder();
            string subquery = $@"SELECT ""Id"" FROM Автомобиль WHERE Номер_Госрегистрации = '{values["auto_registration_number"]}'";

            return updateBuilder
                .FromFields(values)
                .Update("Неисправность", $"\"Id\" = '{values["id"]}'")
                .SetFromFields("Тип_Неисправности", "type")
                .Set("Id_Автомобиля", subquery, true)
                .SetFromFields("Паспорт_Сотрудника", "worker")
                .SetFromFields("Время_Ремонта", "time")
                .GetResult();
        }
    }
}
