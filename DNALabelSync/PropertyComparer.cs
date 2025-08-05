using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DNALabelSync
{
    public class PropertyComparer<T> : IComparer<T>
    {
        private readonly IComparer comparer;

        private PropertyDescriptor propertyDescriptor;

        private int reverse;

        public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            propertyDescriptor = property;
            Type type = typeof(Comparer<>).MakeGenericType(property.PropertyType);
            comparer = (IComparer)type.InvokeMember("Default", BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty, null, null, null);
            SetListSortDirection(direction);
        }

        public int Compare(T x, T y)
        {
            return reverse * comparer.Compare(propertyDescriptor.GetValue(x), propertyDescriptor.GetValue(y));
        }

        private void SetPropertyDescriptor(PropertyDescriptor descriptor)
        {
            propertyDescriptor = descriptor;
        }

        private void SetListSortDirection(ListSortDirection direction)
        {
            reverse = ((direction == ListSortDirection.Ascending) ? 1 : (-1));
        }

        public void SetPropertyAndDirection(PropertyDescriptor descriptor, ListSortDirection direction)
        {
            SetPropertyDescriptor(descriptor);
            SetListSortDirection(direction);
        }
    }
}
