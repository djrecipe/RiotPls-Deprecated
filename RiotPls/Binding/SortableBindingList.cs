using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RiotPls.Binding
{
    public class SortableBindingList<T> : BindingList<T>
    {
        #region Instance Properties
        private bool _IsSortedCore = false;
        protected override bool IsSortedCore => _IsSortedCore;
        private ListSortDirection _SortDirectionCore = ListSortDirection.Ascending;
        protected override ListSortDirection SortDirectionCore => this._SortDirectionCore;
        private PropertyDescriptor _SortPropertyCore = null;
        protected override PropertyDescriptor SortPropertyCore => this._SortPropertyCore;
        protected override bool SupportsSortingCore => true;
        #endregion
        #region Instance Methods
        #region Initialization Methods
        public SortableBindingList(IList<T> list = null)
        {
            if (list == null)
                return;
            foreach (object o in list)
                this.Add((T)o);
            return;
        }
        #endregion
        #endregion
        #region Override Methods
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            Type interface_type = prop.PropertyType.GetInterface("IComparable");

            if (interface_type == null && prop.PropertyType.IsValueType)
                interface_type = Nullable.GetUnderlyingType(prop.PropertyType)?.GetInterface("IComparable");

            if (interface_type == null)
            {
                throw new NotSupportedException(string.Format("Unable to sort by {0} - {1} does not implement 'IComparable'", prop.Name, prop.PropertyType));
            }
            this._SortPropertyCore = prop;
            this._SortDirectionCore = direction;
            IEnumerable<T> query = direction == ListSortDirection.Ascending ? base.Items.OrderBy(i => prop.GetValue(i)) : base.Items.OrderByDescending(i => prop.GetValue(i));
            int index = 0;
            foreach (object item in query)
                this.Items[index++] = (T)item;
            this._IsSortedCore = true;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            return;
        }

        #endregion
    }

}
