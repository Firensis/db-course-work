using DBCourseWork.DB.Exceptions;
using DBCourseWork.DB.Views;
using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork.Forms.Interface
{
    class OperationFormManager
    {
        public string SubmitButtonText { get; set; } = "Отправить запрос";
        public int MarginLeft { get; set; } = 10;
        public int MarginTop { get; set; } = 20;
        public int ItemsMargin { get; set; } = 5;
        public bool ShowSubmitButton { get; set; } = true;

        protected Dictionary<string, Field> fields;
        protected Control container;

        public delegate void SuccessSubmitHandler();
        public event SuccessSubmitHandler SuccessSubmit;
        public delegate void SubmitHandler(Dictionary<string, Field> fields);
        public event SubmitHandler Submit;
        public delegate void ErrorHandler(Exception error);
        public event ErrorHandler Error;

        public OperationFormManager(Control container, Dictionary<string, Field> fields)
        {
            Init(container, fields);

            Submit += EmptySubmitHandler;
        }

        private void EmptySubmitHandler(Dictionary<string, Field> fields)
        {
        }

        protected void Init(Control container, Dictionary<string, Field> fields)
        {
            this.container = container;
            this.fields = fields;
        }

        public void ClearContainer()
        {
            container.Controls.Clear();
        }
        
        protected void AddControl(Control control)
        {
            container.Controls.Add(control);
        }

        public void Build()
        {
            ClearContainer();

            int i = 0;
            int itemHeight = 0;
            int textBoxY = MarginTop;

            foreach (var pair in fields)
            {
                Field field = pair.Value;

                int labelY = MarginTop + (itemHeight + ItemsMargin) * i;
                Label label = new Label
                {
                    Text = field.Title,
                    Location = new System.Drawing.Point(MarginLeft, labelY),
                    AutoSize = true
                };
                AddControl(label);

                textBoxY = labelY + label.Height + 5;

                field.Control.Location = new System.Drawing.Point(MarginLeft, textBoxY);
                AddControl(field.Control);
                i++;
                itemHeight = label.Height + field.Control.Height + 5;
            }

            if (ShowSubmitButton)
            {
                Button button = new Button
                {
                    Text = SubmitButtonText,
                    Location = new System.Drawing.Point(MarginLeft, textBoxY + itemHeight + ItemsMargin)
                };

                button.Click += HandleClick;
                AddControl(button);
            }
        }

        protected void HandleClick(object sender, EventArgs e)
        {
            try
            {
                SubmitForm();
            }
            catch (ExecuteNonSelectException exc)
            {
                Error(exc);
            }
        }

        public void SubmitForm()
        {
            Submit(fields);
            SuccessSubmit();
        }
    }
}
