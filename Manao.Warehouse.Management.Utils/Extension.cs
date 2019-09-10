using Manao.Warehouse.Management.Domain;
using System;
using System.Collections.Generic;

namespace Manao.Warehouse.Management.Utils
{
    public static class Extension
    {
        private static DateTime _default = new DateTime(1970, 1, 1, 0, 0, 0);

        public static IItemHistory CreateHistory(this IItem item)
        {
            return item.As<IItemHistory>();
        }

        public static T As<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        public static long ToUnixTimestamp(this DateTime dt)
        {
            return (dt.Ticks - _default.Ticks) / 10000000;
        }

        public static DateTime FromUnixTimestamp(this long timestamp)
        {
            return _default.AddSeconds(timestamp);
        }

        public static T AsEnum<T>(this string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString, true);
        }

        #region calculation

        public static double Mean(this IList<double> values)
        {
            return values.Count == 0 ? 0 : values.Mean(0, values.Count);
        }

        public static double Mean(this IList<double> values, int start, int end)
        {
            double s = 0;

            for (int i = start; i < end; i++)
            {
                s += values[i];
            }

            return s / (end - start);
        }

        public static double Variance(this IList<double> values)
        {
            return values.Variance(values.Mean(), 0, values.Count);
        }

        public static double Variance(this IList<double> values, double mean)
        {
            return values.Variance(mean, 0, values.Count);
        }

        public static double Variance(this IList<double> values, double mean, int start, int end)
        {
            double variance = 0;

            for (int i = start; i < end; i++)
            {
                variance += Math.Pow((values[i] - mean), 2);
            }

            int n = end - start;
            if (start > 0) n -= 1;

            return variance / (n);
        }

        public static double StandardDeviation(this IList<double> values)
        {
            return values.Count == 0 ? 0 : values.StandardDeviation(0, values.Count);
        }

        public static double StandardDeviation(this IList<double> values, int start, int end)
        {
            double mean = values.Mean(start, end);
            double variance = values.Variance(mean, start, end);

            return Math.Sqrt(variance);
        }

        #endregion
    }
}
