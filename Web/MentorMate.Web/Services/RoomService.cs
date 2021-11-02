using System;
using System.Collections.Generic;
using System.Linq;
using MentorMate.Models;
using MentorMate.Models.ViewModels;

namespace MentorMate.Web.Services
{
    public class RoomService : IRoomService
    {
        private readonly IModifyDateService dateService;

        public RoomService(IModifyDateService dateService)
        {
            this.dateService = dateService;
        }
        public List<RoomViewModel> CreateRoomModel(IEnumerable<BaseModel> baseModels)
        {
            List<RoomViewModel> rooms = new List<RoomViewModel>();

            foreach (var model in baseModels)
            {
                var room = new RoomViewModel()
                {
                    RoomName = model.RoomName,
                    Capacity = model.Capacity,
                    AvailableFrom = this.dateService.ParseTime(model.AvailableFrom),
                    AvailableTo = this.dateService.ParseTime(model.AvailableTo),

                };
                foreach (var item in model.Schedule)
                {
                    room.Schedules.Add(new ScheduleViewModel()
                    {
                        From = this.dateService.DateParse(item.From),
                        To = this.dateService.DateParse(item.To),
                    });
                }
                rooms.Add(room);
            }

            return rooms;
        }
        public List<RoomViewModel> Search(List<RoomViewModel> rooms, DateTime searchByDate, int searchByCount, int searchByDuration)
        {
            var models = rooms.Where(x => x.Capacity == searchByCount).ToList();
            var result = new List<RoomViewModel>();


            foreach (var room in models)
            {
                var newSchedules = new List<ScheduleViewModel>();

                var dateTime = searchByDate.AddHours(room.AvailableFrom.Hours)
                    .AddMinutes(room.AvailableFrom.Minutes);

                var schedules = room.Schedules.ToList();

                var queue = new Queue<ScheduleViewModel>(schedules);


                ScheduleViewModel model;
                while (room.AvailableTo > dateTime.TimeOfDay)
                {
                    var any = schedules.Any(x => x.From.Date == searchByDate);
                    if (queue.Count > 0 && any)
                    {
                        model = queue.Peek();
                        if (dateTime.AddMinutes(searchByDuration) > model.From)
                        {
                            var d = dateTime.AddMinutes(searchByDuration);
                            if (queue.Count > 0)
                            {
                                queue.Dequeue();
                            }
                            dateTime = model.To;
                            continue;
                        }
                    }

                    if (dateTime.AddMinutes(searchByDuration).TimeOfDay > room.AvailableTo)
                    {
                        break;
                    }
                    var schedule = new ScheduleViewModel
                    {
                        From = dateTime,
                        To = dateTime.AddMinutes(searchByDuration)
                    };
                    newSchedules.Add(schedule);
                    dateTime = dateTime.AddMinutes(15);
                }
                result.Add(new RoomViewModel()
                {
                    RoomName = room.RoomName,
                    Capacity = room.Capacity,
                    AvailableFrom = room.AvailableFrom,
                    AvailableTo = room.AvailableTo,
                    Schedules = newSchedules,
                });

            }
            return result;
        }
    }
}
