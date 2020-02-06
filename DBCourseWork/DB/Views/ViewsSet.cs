using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCourseWork.DB.Views.EditableViews;

namespace DBCourseWork.DB.Views
{
    class ViewsSet
    {
        protected Dictionary<string, BaseView> tables;

        public ViewsSet()
        {
            tables = new Dictionary<string, BaseView>();
            AddView(new AutoTable());
            AddView(new OwnerTable());
            AddView(new ProblemTable());
            AddView(new WorkerTable());
            AddView(new ProblemFullInfoView());
            AddView(new FixedCarsView());
        }

        protected void AddView(BaseView table)
        {
            tables[table.Name] = table;
        }

        public bool Any(Predicate<BaseView> condition)
        {
            return tables.Any((keyValue) => condition(keyValue.Value));
        }

        public BaseView[] GetViews(Predicate<BaseView> condition)
        {
            var linqResult = tables
                .Where((keyValuePair) => condition(keyValuePair.Value))
                .Select((keyValue) => keyValue.Value);

            return linqResult.ToArray();
        }
    }
}
