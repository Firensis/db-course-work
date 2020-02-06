using DBCourseWork.DB.Views.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Views
{
    class FixedCarsView : BaseView
    {
        public override string Title => "Получить информацию о сотрудниках и отремонтированных им автомобилях";
        public override string Name => "fixed_cars";

        public override Filter[] GetAviableFilters()
        {
            return new Filter[]
            {
                new Filter
                {
                    Title = "Паспорт сотрудника",
                    SqlFieldName = "Паспорт_Сотрудника"
                },
                new Filter
                {
                    Title = "Фамилия сотрудника",
                    SqlFieldName = "Фамилия"
                },
                new Filter
                {
                    Title = "Имя сотрудника",
                    SqlFieldName = "Имя"
                },
                new Filter
                {
                    Title = "Отчество сотрудника",
                    SqlFieldName = "Отчество"
                },
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
                },

            };
        }

        public override string[] GetTableHeader()
        {
            return new string[]
            {
                "Паспорт сотрудника", "ФИО сотрудника", "Номер госрегистрации", "Марка", "Год выпуска", "Изготовитель"
            };
        }

        protected override string GetSelectSql(Filter filter = null)
        {
            string query = @"
                SELECT ""Паспорт"",
                ""Фамилия"" || ' ' || ""Имя"" || ' ' || ""Отчество"",
                ""Номер_Госрегистрации"", ""Марка"", ""Год_Выпуска"", ""Изготовитель""
                FROM ""Сотрудник""
                JOIN ""Неисправность"" ON (""Неисправность"".""Паспорт_Сотрудника"" = ""Сотрудник"".""Паспорт"")
                JOIN ""Автомобиль"" ON (""Неисправность"".""Id_Автомобиля"" = ""Автомобиль"".""Id"")
            ";

            if (filter != null)
            {
                query += $" WHERE {filter.SqlFieldName} = '{filter.Value}'";
            }

            return query;
        }
    }
}
