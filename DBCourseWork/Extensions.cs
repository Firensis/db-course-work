using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace DBCourseWork
{
    static class Extensions
    {
        public static string Implode(this IEnumerable<object> collection, string separator)
        {
            var enumerator = collection.GetEnumerator();
            string result = "";
            enumerator.MoveNext();
            result += enumerator.Current.ToString();

            while (enumerator.MoveNext())
            {
                result += separator + enumerator.Current.ToString();
            }

            return result;
        }

        public static Table SetAllSidesBorder(this Table table, Border border)
        {
            table.SetBorder(TableBorderType.InsideH, border);
            table.SetBorder(TableBorderType.InsideV, border);
            table.SetBorder(TableBorderType.Top, border);
            table.SetBorder(TableBorderType.Right, border);
            table.SetBorder(TableBorderType.Left, border);
            table.SetBorder(TableBorderType.Bottom, border);

            return table;
        }
    }
}
