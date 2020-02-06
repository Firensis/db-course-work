using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCourseWork.Forms.Interface.Fields
{
    class ComboBoxField : Field
    {
        public int ItemsCount { get => combobox.Items.Count; }
        public override string Value => (string)combobox.SelectedItem;
        public override Control Control => combobox;
        protected ComboBox combobox;
        
        public void ResetSelectedItem()
        {
            combobox.SelectedIndex = 0;
        }

        public delegate void ValueChangedHandler(string newValue);
        public event ValueChangedHandler SelectedValueChanged;

        public ComboBoxField(IEnumerable<string> values, string title = "") : base(title)
        {
            combobox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            combobox.SelectedValueChanged += Combobox_SelectedValueChanged;

            foreach (string value in values)
            {
                combobox.Items.Add(value);
            }

            SelectedValueChanged += ComboBoxField_SelectedValueChanged;
        }

        private void ComboBoxField_SelectedValueChanged(string newValue)
        {
        }

        private void Combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectedValueChanged((string)combobox.SelectedItem);
        }
    }
}
