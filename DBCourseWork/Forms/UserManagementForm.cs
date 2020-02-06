using DBCourseWork.DB.UserSystem;
using DBCourseWork.DB.UserSystem.Exceptions;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.DB.Views.EditableViews;
using DBCourseWork.Forms.Interface;
using DBCourseWork.Forms.Interface.Fields;
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
    public partial class UserManagementForm : Form
    {
        protected UserManager userManager;
        protected User currentUser;
        protected IRole[] roles;
        protected TextField pasportInput;
        Dictionary<string, Field> addWorkerFields;
        OperationFormManager createWorkerFormManager;

        public UserManagementForm()
        {
            InitializeComponent();
            userManager = Program.Container.GetUserManager();
            currentUser = Program.Container.GetCurrentUser();

            roles = new IRole[]
            {
                new Worker(),
                new HighWorker(),
                new Supervisor(),
                new HR()
            };

            foreach (IRole role in roles)
            {
                cb_roleSelect.Items.Add(role.Title);
            }

            cb_roleSelect.SelectedIndex = 0;

            UpdateUsersList();
            InitAddWorkerFields();

            int workerCreateBottomY = p_addToWorker.Location.Y + p_addToWorker.Height;
            b_addUser.Location = new Point(b_addUser.Location.X, workerCreateBottomY + 10);
            int gbUserCreateBottomY = gb_userCreate.Location.Y + gb_userCreate.Height;
        }

        protected void UpdateUsersList()
        {
            cb_userNames.Items.Clear();

            foreach (string user in userManager.GetUsersList())
            {
                if (user != currentUser.UserId)
                {
                    cb_userNames.Items.Add(user);
                }
            }

            if (cb_userNames.Items.Count > 0)
            {
                cb_userNames.Enabled = b_deleteUser.Enabled = true;
                cb_userNames.SelectedIndex = 0;
            }
            else
            {
                cb_userNames.Enabled = b_deleteUser.Enabled = false;
            }
        }
        

        protected void InitAddWorkerFields()
        {
            EditableView worker = Program.Container.GetViewsSet()
                .GetViews((view) => view.Name == "Сотрудник")
                .First() as EditableView;

            addWorkerFields = worker.GetInsertFields();
            pasportInput = addWorkerFields["pasport"] as TextField;
            pasportInput.PreventSet = true;

            createWorkerFormManager = new OperationFormManager(p_addToWorker, addWorkerFields)
            {
                ShowSubmitButton = false
            };
            createWorkerFormManager.Submit += worker.InsertValuesFromFields;
            createWorkerFormManager.Error += FormManager_Error;
            createWorkerFormManager.Build();
            createWorkerFormManager.SuccessSubmit += AddWorkerFormManager_SuccessSubmit;
        }

        private void FormManager_Error(Exception error)
        {
            string userId = tb_userId.Text;
            userManager.DeleteUser(userId);
            MessageBox.Show($"При создании записи в таблице \"Сотрудник\" возникла ошибка: {error.Message}");
        }

        private void AddWorkerFormManager_SuccessSubmit()
        {
            MessageBox.Show("Пользователь и соответствующая запись в таблице \"Сотрудник\" успешно добавлены!");
        }

        private void Cb_addToWorker_CheckedChanged(object sender, EventArgs e)
        {
            p_addToWorker.Enabled = !p_addToWorker.Enabled;
        }

        private void tb_userId_TextChanged(object sender, EventArgs e)
        {
            TextBox cur = (TextBox)sender;

            pasportInput.SetValue(cur.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            userManager.DeleteUser(cb_userNames.SelectedItem.ToString());
            UpdateUsersList();
            MessageBox.Show("Пользователь успешно удалён!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            try
            {
                AddUser();
                
                if (cb_addToWorker.Checked)
                {
                    createWorkerFormManager.SubmitForm();
                }
                else
                {
                    MessageBox.Show("Пользователь успешно создан!");
                }
            }
            catch (AddUserException exc)
            {
                MessageBox.Show("При попытке создания пользователя возникла ошибка: " + exc.Message);
            }
        }

        protected bool ValidateFields()
        {
            bool workerOk = true;

            if (cb_addToWorker.Checked)
            {
                foreach (var pair in addWorkerFields)
                {
                    if (pair.Value.Value == "")
                    {
                        workerOk = false;
                        break;
                    }
                }
            }

            if (tb_userId.Text == "" || tb_userPassword.Text == "" || !workerOk)
            {
                MessageBox.Show("Не заполнены некоторые поля!");
                return false;
            }

            return true;
        }

        protected void AddUser()
        {
            IRole selectedRole = roles[cb_roleSelect.SelectedIndex];

            userManager.AddUser(tb_userId.Text, tb_userPassword.Text, selectedRole);
            UpdateUsersList();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Program.Container.GetFormSystem().ShowMenuForm();
        }
    }
}
