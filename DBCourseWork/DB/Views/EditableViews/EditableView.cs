using DBCourseWork.DB.UserSystem;
using DBCourseWork.DB.UserSystem.Permissions;
using DBCourseWork.DB.UserSystem.Role;
using DBCourseWork.Forms.Interface.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Views.EditableViews
{
    abstract public class EditableView : BaseView
    {
        protected virtual int PrimaryKeyIndex { get; } = 0;
        protected Dictionary<string, object[]> keyValueData;
        
        abstract public Dictionary<string, Field> GetInsertFields();
        abstract public Dictionary<string, Field> GetUpdateFields();
        abstract public Dictionary<string, Field> GetDeleteFields();

        abstract protected string GetInsertSql(Dictionary<string, Field> values);
        abstract protected string GetUpdateSql(Dictionary<string, Field> values);
        abstract protected string GetDeleteSql(Dictionary<string, Field> values);

        protected override void BeforeLoadData()
        {
            base.BeforeLoadData();
            keyValueData = new Dictionary<string, object[]>();
        }

        protected override object[] CreateRow(object[] values)
        {
            string primary = values[PrimaryKeyIndex].ToString();
            keyValueData[primary] = values;

            return base.CreateRow(values);
        }

        public virtual void InsertValuesFromFields(Dictionary<string, Field> fields)
        {
            string sql = GetInsertSql(fields);
            queryExecutor.ExecuteNonSelect(sql);
        }

        public virtual void UpdateItemFromFields(Dictionary<string, Field> fields)
        {
            string sql = GetUpdateSql(fields);
            queryExecutor.ExecuteNonSelect(sql);
        }

        public virtual void DeleteItemWithFields(Dictionary<string, Field> fields)
        {
            string sql = GetDeleteSql(fields);
            queryExecutor.ExecuteNonSelect(sql);
        }
    }
}
