using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork
{
    static class Program
    {
        public static Container Container { get; private set; }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Container = new Container();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Container.GetFormSystem().Start();
            Application.Run();
        }
    }
}
