using DBCourseWork.DB.Views;
using DBCourseWork.DB.Views.EditableViews;
using DBCourseWork.DocumentCreator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork.Forms
{
    public partial class CreateReferenceForm : Form
    {
        const string PROBLEM_VIEW_NAME = "Неисправность";
        ProblemTable problemView;
        ReferenceCreator refCreator;

        public CreateReferenceForm()
        {
            InitializeComponent();
            var viewsSet = Program.Container.GetViewsSet();
            problemView = (ProblemTable)viewsSet.GetViews(view => view.Name == PROBLEM_VIEW_NAME).First();

            var numbers = problemView.GetFixedAutoWithOwner();

            foreach (string number in numbers)
            {
                cb_autoNumber.Items.Add(number);
            }

            if (cb_autoNumber.Items.Count > 0)
            {
                cb_autoNumber.SelectedIndex = 0;
            }
            else
            {
                cb_autoNumber.Enabled = false;
            }

            refCreator = new ReferenceCreator();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.Container.GetFormSystem().ShowMenuForm();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (sfd_saveReference.ShowDialog() != DialogResult.Cancel)
            {
                refCreator.CreateReference(cb_autoNumber.SelectedItem.ToString(), sfd_saveReference.FileName);
                MessageBox.Show("Справка успешно создана!");
            }
        }
    }
}
