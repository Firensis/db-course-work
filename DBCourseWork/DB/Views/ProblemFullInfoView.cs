using DBCourseWork.DB.Views.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Views
{
    class ProblemFullInfoView : BaseView
    {
        public override string Name => "problem_full_info";
        public override string Title => "Получить информацию о сотрудниках, исправленых ими проблемах, автомобилях и владельцах";

        public override Filter[] GetAviableFilters()
        {
            return new Filter[]
            {
                new Filter
                {
                    Title = "Id неисправности",
                    SqlFieldName = @"""Неисправность"".""Id"""
                },
                new Filter
                {
                    Title = "Паспорт сотрудника",
                    SqlFieldName = "\"Сотрудник\".\"Паспорт\""
                },
                new Filter
                {
                    Title = "Номер автомобиля",
                    SqlFieldName = @"""Автомобиль"".""Номер_Госрегистрации"""
                },
                new Filter
                {
                    Title = "Фамилия владельца",
                    SqlFieldName = @"""Владелец"".""Фамилия"""
                },
                new Filter
                {
                    Title = "Имя владельца",
                    SqlFieldName = @"""Владелец"".""Имя"""
                },
                new Filter
                {
                    Title = "Отчество владельца",
                    SqlFieldName = @"""Владелец"".""Отчество"""
                },
                new Filter
                {
                    Title = "Фамилия сотрудника",
                    SqlFieldName = @"""Сотрудник"".""Фамилия"""
                },
                new Filter
                {
                    Title = "Имя сотрудника",
                    SqlFieldName = @"""Сотрудник"".""Имя"""
                },
                new Filter
                {
                    Title = "Отчество сотрудника",
                    SqlFieldName = @"""Сотрудник"".""Отчество"""
                },
                new Filter
                {
                    Title = "Тип неисправности",
                    SqlFieldName = @"""Неисправность"".""Тип_Неисправности"""
                },
                new Filter
                {
                    Title = "Время ремонта",
                    SqlFieldName = @"""Неисправность"".""Время_Ремонта"""
                }
            };
        }

        public override string[] GetTableHeader()
        {
            return new string[]
            {
                "Идентификатор неисправности", "Номер авто", "ФИО владельца", "Паспорт сотрудника", "ФИО сотрудника", "Тип неисправности", "Время ремонта"
            };
        }

        protected override string GetSelectSql(Filter filter = null)
        {
            string query = @"
                SELECT ""Неисправность"".""Id"", 
                ""Автомобиль"".""Номер_Госрегистрации"", 
                ""Владелец"".""Фамилия"" || ' ' || ""Владелец"".""Имя"" || ' ' || ""Владелец"".""Отчество"",
                ""Сотрудник"".""Паспорт"",
				""Сотрудник"".""Фамилия"" || ' ' || ""Сотрудник"".""Имя"" || ' ' || ""Сотрудник"".""Отчество"",
                ""Неисправность"".""Тип_Неисправности"",
                ""Неисправность"".""Время_Ремонта""
                FROM ""Автомобиль"" 
                LEFT JOIN ""Владелец"" ON (""Автомобиль"".""Id"" = ""Владелец"".""Id_Автомобиля"")
                JOIN ""Неисправность"" ON (""Неисправность"".""Id_Автомобиля"" = ""Автомобиль"".""Id"")
                JOIN ""Сотрудник"" ON (""Неисправность"".""Паспорт_Сотрудника"" = ""Сотрудник"".""Паспорт"")
            ";

            if (filter != null)
            {
                query += $@" WHERE {filter.SqlFieldName} = '{filter.Value}'";
            }

            return query;
        }
    }
}
