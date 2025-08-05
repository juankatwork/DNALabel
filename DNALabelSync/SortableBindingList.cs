using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNALabelSync
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private readonly Dictionary<Type, PropertyComparer<T>> comparers;

        private bool isSorted;

        private ListSortDirection listSortDirection;

        private PropertyDescriptor propertyDescriptor;

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => isSorted;

        protected override PropertyDescriptor SortPropertyCore => propertyDescriptor;

        protected override ListSortDirection SortDirectionCore => listSortDirection;

        protected override bool SupportsSearchingCore => true;

        public SortableBindingList()
            : base((IList<T>)new List<T>())
        {
            comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        public SortableBindingList(IEnumerable<T> enumeration)
            : base((IList<T>)new List<T>(enumeration))
        {
            comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> list = (List<T>)base.Items;
            Type propertyType = property.PropertyType;
            if (!comparers.TryGetValue(propertyType, out var value))
            {
                value = new PropertyComparer<T>(property, direction);
                comparers.Add(propertyType, value);
            }

            value.SetPropertyAndDirection(property, direction);
            list.Sort(value);
            propertyDescriptor = property;
            listSortDirection = direction;
            isSorted = true;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            propertyDescriptor = base.SortPropertyCore;
            listSortDirection = base.SortDirectionCore;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = base.Count;
            for (int i = 0; i < count; i++)
            {
                T val = base[i];
                if (property.GetValue(val).Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
