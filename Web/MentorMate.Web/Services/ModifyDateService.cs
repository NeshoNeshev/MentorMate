using System;
using System.Globalization;

namespace MentorMate.Web.Services
{
    public class ModifyDateService : IModifyDateService
    {
        public TimeSpan ParseTime(string timeInput)
        {
            TimeSpan time = DateTime.ParseExact(
                timeInput,
                "HH:mm",
                CultureInfo.InvariantCulture
            ).TimeOfDay;

            return time;
        }
        public DateTime DateParse(string dateTime)
        {
            var date = DateTime.Parse(dateTime);



            return date;
        }

        public DateTime GetDate(DateTime date)
        {
            return date.Date;
        }
    }
}
