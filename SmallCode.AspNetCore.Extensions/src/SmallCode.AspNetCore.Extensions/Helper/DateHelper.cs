using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Helper
{
    public class DateHelper
    {
        #region 获取时间戳
        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion


        /// <summary>
        /// 两个时间之间的天数
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int DifferenceDays(DateTime time1, DateTime time2)
        {
            int ret = 0;
            ret = (time1 - time2).Days;
            return ret;
        }

        /// <summary>
        ///  两个时间段中 一共有几周
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int WhichWeek(DateTime begin, DateTime end)
        {
            DateTime firstDay = begin;
            //一.找到第一周的最后一天（先获取1月1日是星期几，从而得知第一周周末是几）
            int firstWeekend = firstDay.DayOfYear + (7 - Convert.ToInt32(firstDay.DayOfWeek));

            //二.获取今天是一年当中的第几天
            int currentDay = end.DayOfYear;
            //三.（最后一天 减去 第一周周末那一天）/7 等于 距第一周有多少周 再加上第一周的1 就是这个月的周数
            //刚好考虑了惟一的特殊情况就是，今天刚好在第一周内，那么距第一周就是0 再加上第一周的1 最后还是1
            int result = Convert.ToInt32(Math.Ceiling((currentDay - firstWeekend) / 7.0)) + 1;

            return result;
        }


        /// <summary>
        /// 某段时间 几周后的日期
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime GetDate(DateTime Begin, int week)
        {
            DateTime time = Begin.AddDays(week * 7);
            return time;
        }
    }
}
