using TourPlannerBL.Util;

namespace TourPlannerBL.Util
{
    public static class LinqExtensions
    {
        //Sum calculation for TimeSpan
        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> func)
        {
            return new TimeSpan(source.Sum(item => func(item).Ticks));
        }

        //Average calculation for TimeSpan
        public static TimeSpan Average<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> func)
        {
            return new TimeSpan((long)source.Average(item => func(item).Ticks));
        }

        //Stringformatting for TimeSpan? 
        public static string ToString(this TimeSpan? ts, string format)
            => ts == null ? "" : ((TimeSpan)ts).ToString(format);
    }
}
