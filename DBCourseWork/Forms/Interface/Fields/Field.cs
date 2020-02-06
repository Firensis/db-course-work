using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork.Forms.Interface.Fields
{
    public abstract class Field
    {
        abstract public string Value { get; }
        abstract public Control Control { get; }
        public string Title { get; set; } = "";
        public virtual bool PreventSet { get; set; } = false;

        public Field(string title = "")
        {
            Title = title;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
