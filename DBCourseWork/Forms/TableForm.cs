using DBCourseWork.DB.UserSystem;
using DBCourseWork.DB.UserSystem.Permissions;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.DB.Views;
using DBCourseWork.DB.Views.EditableViews;
using DBCourseWork.DB.Views.EditableViews.Exceptions;
using DBCourseWork.DB.Views.Structures;
using DBCourseWork.Forms.Interface;
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
    public partial class TableForm : Form
    {
        protected const string rowsCountStringFormat = "Количеcтво отображёных записей: {0}";
        protected BaseView currentView;
        protected BaseView[] permittedTables;
        protected ViewPermissions currentPermissions;
        Filter[] filters;
        protected object[][] data;
        int rows;
        int curTableIndex = -1;

        public TableForm()
        {
            InitializeComponent();
            InitViews();
        }

        protected void InitViews()
        {
            var viewsSet = Program.Container.GetViewsSet();
            User currentUser = Program.Container.GetCurrentUser();
            permittedTables = viewsSet.GetViews((table) => table.GetPermissionsOf(currentUser).Select);

            foreach (BaseView table in permittedTables)
            {
                cb_table.Items.Add(table.Title);
            }

            cb_table.SelectedIndex = 0;
        }

        private void Cb_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInterface();
            UpdateInsertInterface();
        }

        protected void UpdateCurrentTable(Filter filter = null)
        {
            int tableNumber = cb_table.SelectedIndex;

            if (curTableIndex != tableNumber)
            {
                curTableIndex = tableNumber;
                currentView = permittedTables[tableNumber];
                currentPermissions = currentView.GetPermissionsOf(Program.Container.GetCurrentUser());
                UpdateFilters();
            }

            currentView.LoadData(filter);
            data = currentView.GetData();
            ShowData();
        }

        protected void UpdateFilters()
        {
            cb_filter.Items.Clear();
            cb_filter.Items.Add("Без фильтра");

            filters = currentView.GetAviableFilters();

            foreach (var filter in filters)
            {
                cb_filter.Items.Add(filter.Title);
            }

            tb_filterValue.Text = "";
            cb_filter.SelectedIndex = 0;
        }

        protected void ShowData()
        {
            dg_tableView.Rows.Clear();
            dg_tableView.Columns.Clear();
            rows = data.Length;

            if (rows > 0)
            {
                dg_tableView.RowCount = rows;
                string[] columns = currentView.GetTableHeader();
                dg_tableView.Columns[0].HeaderText = columns[0];

                for (int i = 1; i < columns.Length; i++)
                {
                    dg_tableView.Columns.Add(columns[i], columns[i]);
                }

                for (int i = 0; i < data.Length; i++)
                {
                    for (int j = 0; j < columns.Length; j++)
                    {
                        dg_tableView.Rows[i].Cells[j].Value = data[i][j];
                    }
                }
            }

            l_rowsCount.Text = string.Format(rowsCountStringFormat, rows);
        }

        protected void UpdateInsertInterface()
        {
            if (currentPermissions.Insert && currentView is EditableView currentTable)
            {
                gb_addItem.Visible = true;
                OperationFormManager inserter = new OperationFormManager(gb_addItem, currentTable.GetInsertFields())
                {
                    SubmitButtonText = "Добавить"
                };
                inserter.Submit += currentTable.InsertValuesFromFields;
                inserter.Error += OperationErrorHandler;
                inserter.Build();
                inserter.SuccessSubmit += SuccessItemInserted;
            }
            else
            {
                gb_addItem.Visible = false;
            }
        }

        protected void TryUpdateUpdateInterface()
        {
            try
            {
                UpdateUpdateInterface();
            } catch (NoRowsToEditException)
            {
                gb_changeItem.Visible = false;
            }
        }

        protected void UpdateUpdateInterface()
        {
            if (currentPermissions.Update && rows > 0 && currentView is EditableView currentTable)
            {
                gb_changeItem.Visible = true;
                OperationFormManager updater = new OperationFormManager(gb_changeItem, currentTable.GetUpdateFields())
                {
                    SubmitButtonText = "Изменить"
                };
                updater.Submit += currentTable.UpdateItemFromFields;
                updater.Error += OperationErrorHandler;
                updater.Build();
                updater.SuccessSubmit += SuccessItemUpdated;
            }
            else
            {
                gb_changeItem.Visible = false;
            }
        }

        protected void TryUpdateDeleteInterface()
        {
            try
            {
                UpdateDeleteInterface();
            }
            catch (NoRowsToEditException)
            {
                gb_deleteItem.Visible = false;
            }
        }

        protected void UpdateDeleteInterface()
        {
            if (currentPermissions.Delete && rows > 0 && currentView is EditableView currentTable)
            {
                gb_deleteItem.Visible = true;
                OperationFormManager deleter = new OperationFormManager(gb_deleteItem, currentTable.GetDeleteFields())
                {
                    SubmitButtonText = "Удалить"
                };

                deleter.Submit += currentTable.DeleteItemWithFields;
                deleter.Error += OperationErrorHandler;
                deleter.Build();
                deleter.SuccessSubmit += SuccessItemDelete;
            }
            else
            {
                gb_deleteItem.Visible = false;
            }
        }

        private void OperationErrorHandler(Exception error)
        {
            MessageBox.Show($"При выполнении операции произошла ошибка: {error.Message}");
        }

        private void SuccessItemDelete()
        {
            UpdateInterface();
            MessageBox.Show("Элемент успешно удалён");
        }

        private void SuccessItemInserted()
        {
            UpdateInterface();
            MessageBox.Show("Элемент успешно добавлен");
        }

        private void SuccessItemUpdated()
        {
            UpdateInterface();
            MessageBox.Show("Элемент успешно изменён");
        }

        protected void UpdateInterface(Filter filter = null)
        {
            UpdateCurrentTable(filter);
            TryUpdateUpdateInterface();
            TryUpdateDeleteInterface();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int filterIndex = cb_filter.SelectedIndex - 1;

            Filter curFilter = null;

            if (filterIndex >= 0)
            {
                curFilter = filters[filterIndex];
                curFilter.Value = tb_filterValue.Text;
            }

            UpdateInterface(curFilter);
        }

        private void cb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_filter.SelectedIndex == 0)
            {
                tb_filterValue.Text = "";
                tb_filterValue.Enabled = false;
                UpdateInterface();
            }
            else
            {
                tb_filterValue.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Program.Container.GetFormSystem().ShowMenuForm();
        }
    }
}
