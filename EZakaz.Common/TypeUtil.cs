using System;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections.Generic;

namespace EZakaz.Common
{
    public static class TypeUtil
    {
        public static TValue GetValue<TValue>(object obj, TValue defaultValue)
        {
            return (obj is TValue) ? (TValue)obj : defaultValue;
        }

        public static TItem[] GetArray<TItem>(ICollection<TItem> items)
        {
            if (items == null)
                return null;

            TItem[] result = new TItem[items.Count];
            items.CopyTo(result, 0);
            return result;
        }

        public static IList<TItem> GetList<TItem>(TItem[] items)
        {
            if (items == null)
                return null;

            IList<TItem> listItems = new List<TItem>(items);
            return listItems;
        }

        public static ISet<TItem> GetSet<TItem>(TItem[] items)
        {
            if (items == null)
                return null;

            ISet<TItem> setItems = new HashedSet<TItem>(items);
            return setItems;
        }

        public static IList<TItem> GetList<TItem>(ISet<TItem> items)
        {
            if (items == null) return null;
            IList<TItem> list = new List<TItem>(items.Count);
            AddToList<TItem>(list, items);
            return list;
        }

        public static void AddToList<TItem>(IList<TItem> list, ISet<TItem> items)
        {
            if (items != null)
                foreach (TItem item in items)
                    list.Add(item);
        }
    }

}
