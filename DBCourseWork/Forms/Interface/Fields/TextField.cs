using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork.Forms.Interface.Fields
{
    public class TextField : Field
    {
        protected TextBox textbox;
        public override string Value { get => textbox.Text; }
        public Point Location { get => textbox.Location; set => textbox.Location = value; }
        public override bool PreventSet { get => !textbox.Enabled; set => textbox.Enabled = !value; }

        public override Control Control => textbox;

        public TextField(string title = "", string value = "") : base(title)
        {
            textbox = new TextBox
            {
                Text = value
            };
        }

        public void SetValue(string value)
        {
            textbox.Text = value;
        }

        public void SetValue(object value)
        {
            SetValue(value.ToString());
        }
    }
}
