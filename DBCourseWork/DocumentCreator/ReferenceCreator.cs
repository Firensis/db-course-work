using DBCourseWork.DB;
using DBCourseWork.DB.Views.EditableViews;
using DBCourseWork.DB.Views.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace DBCourseWork.DocumentCreator
{
    class ReferenceCreator
    {
        protected string autoNumber;
        protected ProblemTable problems = new ProblemTable();
        protected QueryExecutor executor = Program.Container.GetConnection().GetQueryExecutor();

        public void CreateReference(string autoNumber, string filename)
        {
            this.autoNumber = autoNumber;
            DocX doc = DocX.Create(filename);
            doc.InsertParagraph("Справка о наличии неисправностей")
                .FontSize(14)
                .Alignment = Alignment.center;

            var p = doc.InsertParagraph();
            p.AppendLine("Владелец: " + GetOwnerFIO());
            p.AppendLine("Номер госрегистрации автомобиля: " + autoNumber);
            p.AppendLine();
            
            var problems = GetProblems();
            Table table = doc.InsertTable(problems.Length + 1, problems[0].Length);

            table.Alignment = Alignment.center;
            table.SetAllSidesBorder(new Border());
            table.Rows[0].Cells[0].InsertParagraph("Id");
            table.Rows[0].Cells[1].InsertParagraph("Тип неисправности");
            table.Rows[0].Cells[2].InsertParagraph("Время ремонта");
            table.AutoFit = AutoFit.Contents;

            for (int i = 0; i < problems.Length; i++)
            {
                for (int j = 0; j < problems[0].Length; j++)
                {
                    table.Rows[i + 1].Cells[j]
                        .InsertParagraph(problems[i][j].ToString())
                        ;
                }
            }

            doc.Save();
        }

        protected string GetOwnerFIO()
        {
            var data = executor.ExecuteSelectFetchAll($@"
        SELECT Фамилия || ' ' ||  Имя || ' ' || Отчество FROM ""Владелец"" 
        WHERE ""Id_Автомобиля"" = (SELECT ""Id"" FROM Автомобиль WHERE Номер_Госрегистрации = '{autoNumber}' LIMIT 1) 
        LIMIT 1
");

            if (data.Length == 1)
            {
                return data[0][0].ToString();
            }
            else
            {
                return "<отсутствует>";
            }
        }

        protected object[][] GetProblems()
        {
            return executor.ExecuteSelectFetchAll($@"
            SELECT ""Id"", ""Тип_Неисправности"", ""Время_Ремонта"" FROM ""Неисправность""
            WHERE ""Id_Автомобиля"" = (SELECT ""Id"" FROM Автомобиль WHERE Номер_Госрегистрации = '{autoNumber}' LIMIT 1) 
            ");
        }
    }
}
