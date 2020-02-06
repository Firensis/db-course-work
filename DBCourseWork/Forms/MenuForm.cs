using DBCourseWork.DB.UserSystem;
using DBCourseWork.DB.UserSystem.Permissions;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.DocumentCreator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork.Forms
{
    public partial class MenuForm : Form
    {
        FormSystem formSystem;

        public MenuForm()
        {
            InitializeComponent();
            formSystem = Program.Container.GetFormSystem();
            User currentUser = Program.Container.GetCurrentUser();
            b_tables.Enabled = Program.Container.GetViewsSet().Any(
                (table) => table.GetPermissionsOf(currentUser).Select
            );
            b_userManagement.Enabled = currentUser.Role is Superuser || currentUser.Role is HR;
            button1.Enabled = currentUser.Role is Superuser || currentUser.Role is Supervisor;
            b_createReport.Enabled = currentUser.Role is Superuser || currentUser.Role is Supervisor;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void B_tables_Click(object sender, EventArgs e)
        {
            formSystem.ShowTableForm();
        }

        private void B_createUser_Click(object sender, EventArgs e)
        {
            formSystem.ShowUserManagementForm();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            formSystem.ShowCreateReferenceForm();
        }

        private void B_createReport_Click(object sender, EventArgs e)
        {
            if (sfd_saveReport.ShowDialog() != DialogResult.Cancel)
            {
                ReportCreator creator = new ReportCreator();
                creator.CreateReport(sfd_saveReport.FileName);
                MessageBox.Show("Отчёт успешно создан!");
            }
        }
    }
}
