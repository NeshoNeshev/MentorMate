using System.Collections.Generic;
using MentorMate.Models.InputModels;
using Newtonsoft.Json;

namespace MentorMate.Models
{
    public class BaseModel
    {

        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("availableFrom")]
        public string AvailableFrom { get; set; }

        [JsonProperty("availableTo")]
        public string AvailableTo { get; set; }

        [JsonProperty("schedule")]
        public ICollection<ScheduleInputModel> Schedule { get; set; }
    }
}
