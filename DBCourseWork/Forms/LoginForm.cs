using DBCourseWork.DB.Exceptions;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = tb_login.Text;
            string password = tb_password.Text;

            try
            {
                Program.Container.GetConnection().Open(userName, password);
                Program.Container.GetFormSystem().ShowMenuForm();
            }
            catch (AuthorizeException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
