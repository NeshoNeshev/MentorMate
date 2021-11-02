using System;
using System.Collections.Generic;

namespace MentorMate.Models.ViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel()
        {
            this.Schedules = new List<ScheduleViewModel>();
        }
        public string RoomName { get; set; }

        public int Capacity { get; set; }

        public TimeSpan AvailableFrom { get; set; }

        public TimeSpan AvailableTo { get; set; }

        public ICollection<ScheduleViewModel> Schedules { get; set; }
    }
}
