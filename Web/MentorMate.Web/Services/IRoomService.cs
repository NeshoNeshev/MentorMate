using System;
using System.Collections.Generic;
using MentorMate.Models;
using MentorMate.Models.ViewModels;

namespace MentorMate.Web.Services
{
    public interface IRoomService
    {
        public List<RoomViewModel> CreateRoomModel(IEnumerable<BaseModel> baseModels);

        public List<RoomViewModel> Search(List<RoomViewModel> rooms, DateTime searchByDate, int searchByCount, int searchByDuration);
    }
}
