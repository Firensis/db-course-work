using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork.Forms
{
    public class FormSystem
    {
        protected Form currentForm;
        protected bool preventAppClose = false;

        public void Start()
        {
            SetCurrent(CreateLoginForm());
        }

        public void ShowLoginForm()
        {
            ChangeCurrent(CreateLoginForm());
        }

        public void ShowMenuForm()
        {
            ChangeCurrent(CreateMenuForm());
        }

        public void ShowTableForm()
        {
            ChangeCurrent(CreateTableForm());
        }

        public void ShowUserManagementForm()
        {
            ChangeCurrent(CreateUserManagementForm());
        }

        public void ShowCreateReferenceForm()
        {
            ChangeCurrent(CreateCreateReferenceForm());
        }

        protected virtual Form CreateLoginForm()
        {
            return new LoginForm();
        }

        protected virtual Form CreateMenuForm()
        {
            return new MenuForm();
        }

        protected virtual Form CreateTableForm()
        {
            return new TableForm();
        }
        
        protected virtual Form CreateUserManagementForm()
        {
            return new UserManagementForm();
        }

        protected virtual Form CreateCreateReferenceForm()
        {
            return new CreateReferenceForm();
        }

        protected void ChangeCurrent(Form newCurrent)
        {
            preventAppClose = true;
            currentForm.Close();
            preventAppClose = false;
            SetCurrent(newCurrent);
        }

        protected void SetCurrent(Form newCurrent)
        {
            currentForm = newCurrent;
            currentForm.FormClosed += OnFormClosed;
            currentForm.Show();
        }

        protected void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (!preventAppClose)
            {
                Application.Exit();
            }
        }
    }
}
