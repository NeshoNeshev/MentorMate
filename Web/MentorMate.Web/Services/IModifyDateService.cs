using System;

namespace MentorMate.Web.Services
{
    public interface IModifyDateService
    {
        public TimeSpan ParseTime(string timeInput);
        public DateTime DateParse(string dateTime);

        public DateTime GetDate(DateTime date);
    }
}
