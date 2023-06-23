using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlannerBL
{
    public static class LinqExtensions
    {
        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> func)
        {
            return new TimeSpan(source.Sum(item => func(item).Ticks));
        }

        public static TimeSpan Average<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> func)
        {
            return new TimeSpan((long)source.Average(item => func(item).Ticks));
        }

        public static string ToString(this TimeSpan? ts, string format)
            => ts == null ? "" : ((TimeSpan)ts).ToString(format);
    }
}
