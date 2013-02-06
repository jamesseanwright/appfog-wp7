using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AppFogWP7.Utils
{
    public class DateUtils
    {
        public static DateTime TimeStampToDateTime(double timestamp)
        {
            DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            baseDate = baseDate.AddSeconds(timestamp).ToLocalTime();
            return baseDate;
        }
    }
}
