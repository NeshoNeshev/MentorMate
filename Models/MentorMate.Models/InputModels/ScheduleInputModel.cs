using Newtonsoft.Json;

namespace MentorMate.Models.InputModels
{
    public class ScheduleInputModel
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }
}
