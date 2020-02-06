using DBCourseWork.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace DBCourseWork.DocumentCreator
{
    class ReportCreator
    {
        protected QueryExecutor executor = Program.Container.GetConnection().GetQueryExecutor();

        public void CreateReport(string filename)
        {
            DocX doc = DocX.Create(filename);

            doc.InsertParagraph("Отчёт о работе станции техобслуживания")
                .Bold()
                .FontSize(14)
                .Font("Times New Roman")
                .AppendLine()
                .Alignment = Alignment.center;

            doc.InsertParagraph("Количество автомобилей в базе: " + GetCarsCount())
                .FontSize(14)
                .Font("Times New Roman")
                .AppendLine()
                ;

            doc.InsertParagraph("Неисправности: ")
                .FontSize(14)
                .Font("Times New Roman")
                .AppendLine();

            var data = GetProblemsInfo();

            Table table = doc.InsertTable(data.Length + 1, data[0].Length);

            table.Alignment = Alignment.center;
            table.SetAllSidesBorder(new Border());

            var firstRow = table.Rows[0];

            firstRow.Cells[0].InsertParagraph("Id");
            firstRow.Cells[1].InsertParagraph("Номер автомобиля");
            firstRow.Cells[2].InsertParagraph("Марка");
            firstRow.Cells[3].InsertParagraph("Время ремонта");
            firstRow.Cells[4].InsertParagraph("ФИО сотрудника");

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[0].Length; j++)
                {
                    table.Rows[i + 1].Cells[j].InsertParagraph(data[i][j].ToString());
                }
            }

            doc.Save();
        }

        protected int GetCarsCount()
        {
            var result = executor.ExecuteSelectFetchAll(@"SELECT COUNT(""Id"") FROM ""Автомобиль""");

            int r = int.Parse(result[0][0].ToString());

            return r;
        }

        protected object[][] GetProblemsInfo()
        {
            return executor.ExecuteSelectFetchAll(@"
            SELECT ""Неисправность"".""Id"", 
            ""Автомобиль"".""Номер_Госрегистрации"", 
            ""Автомобиль"".""Марка"",
            ""Неисправность"".""Время_Ремонта"",
            ""Сотрудник"".""Фамилия"" || ' ' || ""Сотрудник"".""Имя"" || ' ' || ""Сотрудник"".""Отчество""
            FROM ""Неисправность"" 
            JOIN ""Автомобиль"" ON (""Неисправность"".""Id_Автомобиля"" = ""Автомобиль"".""Id"") 
            JOIN ""Сотрудник"" ON (""Неисправность"".""Паспорт_Сотрудника"" = ""Сотрудник"".""Паспорт"")
            ORDER BY ""Автомобиль"".""Марка""
            ");
        }
    }
}
