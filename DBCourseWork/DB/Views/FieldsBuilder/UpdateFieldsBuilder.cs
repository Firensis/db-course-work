using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Views.FieldsBuilder
{
    class UpdateFieldsBuilder
    {
        protected Dictionary<string, Field> result;
        protected Dictionary<string, object[]> keyValueData;
        protected ComboBoxField primary;
        protected Dictionary<int, TextField> textFields;

        public UpdateFieldsBuilder BuildNew(Dictionary<string, object[]> keyValueData)
        {
            textFields = new Dictionary<int, TextField>();
            result = new Dictionary<string, Field>();
            this.keyValueData = keyValueData;

            return this;
        }

        public UpdateFieldsBuilder SetPrimary(string key, IEnumerable<string> values, string title = "")
        {
            primary = new ComboBoxField(values, title);
            result[key] = primary;

            return this;
        }

        public UpdateFieldsBuilder SetPrimary(string key, string title = "")
        {
            SetPrimary(key, keyValueData.Keys, title);

            return this;
        }

        public UpdateFieldsBuilder AddTextField(string key, TextField field, int indexInRow)
        {
            textFields[indexInRow] = field;
            result[key] = field;

            return this;
        }

        public Dictionary<string, Field> GetResult()
        {
            var keyValueData = this.keyValueData;
            var textFields = this.textFields;

            primary.SelectedValueChanged += (string newValue) =>
            {
                object[] newCurrent = keyValueData[newValue];

                foreach (var pair in textFields)
                {
                    pair.Value.SetValue(newCurrent[pair.Key]);
                }
            };

            if (primary.ItemsCount > 0)
            {
                primary.ResetSelectedItem();
            }
            
            return result;
        }
    }
}
