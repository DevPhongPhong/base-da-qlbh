using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ultilities
{
    public static class StringExtensions
    {
        public static void TrimAllStrings<TSelf>(this TSelf obj)
        {
            if (obj == null)
                return;

            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

            foreach (PropertyInfo p in obj.GetType().GetProperties(flags))
            {
                Type currentNodeType = p.PropertyType;
                if (currentNodeType == typeof(String))
                {
                    string currentValue = (string)p.GetValue(obj, null);
                    if (currentValue != null)
                    {
                        p.SetValue(obj, currentValue.Trim(), null);
                    }
                }
                // see http://stackoverflow.com/questions/4444908/detecting-native-objects-with-reflection
                else if (currentNodeType != typeof(object) && Type.GetTypeCode(currentNodeType) == TypeCode.Object)
                {
                    if (p.GetIndexParameters().Length == 0)
                    {
                        p.GetValue(obj, null).TrimAllStrings();
                    }
                    else
                    {
                        p.GetValue(obj, new Object[] { 0 }).TrimAllStrings();
                    }
                }
            }
        }
    }
    public static class FomartNumber
    {
        public static string ToStringMoney(this decimal price)
        {
            var str = price.ToString("N0").Replace(",", ".");
            return str;
        }
        public static string ToStringMoney(this decimal? price)
        {
            var str = (price ?? 0).ToString("N0").Replace(",", ".") + " VND";
            return str;
        }
        public static string ToStringMoney(this double price)
        {
            var str = price.ToString("N0").Replace(",", ".") + " VND";
            return str;
        }
        public static string ToStringMoney(this double? price)
        {
            var str = (price ?? 0).ToString("N0").Replace(",", ".") + " VND";
            return str.Trim();
        }
        public static string ToStringQuantity(this decimal quantity, string sub = "")
        {
            var str = quantity.ToString("N0").Replace(",", ".");
            if (!string.IsNullOrEmpty(sub))
                return str.Trim() + sub;
            return str.Trim();
        }
        public static string ToStringQuantity(this double quantity, string sub = "")
        {
            var str = quantity.ToString("N0").Replace(",", ".");
            if (!string.IsNullOrEmpty(sub))
                return str.Trim() + sub;
            return str.Trim();
        }
        public static string ToStringQuantity(this int quantity, string sub = "")
        {
            var str = quantity.ToString("N0").Replace(",", ".");
            if (!string.IsNullOrEmpty(sub))
                return str.Trim() + sub;
            return str;
        }
        public static string ToStringQuantity(this decimal? quantity)
        {
            var str = (quantity ?? 0).ToString("N0").Replace(",", ".");
            return str;
        }
        public static string ToStringQuantity(this double? quantity)
        {
            var str = (quantity ?? 0).ToString("N0").Replace(",", ".");
            return str;
        }
        public static string ToStringQuantity(this int? quantity)
        {
            var str = (quantity ?? 0).ToString("N0").Replace(",", ".");
            return str;
        }
    }
}
