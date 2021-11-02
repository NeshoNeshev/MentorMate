using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MentorMate.Models;

namespace MentorMate.Web.Factories
{
    public class CreateRoomFactory : IFactory<IEnumerable<BaseModel>>
    {
        private readonly string seedingRoom = File.ReadAllText("JsonFile/SeedingRoom.json");

        public IEnumerable<BaseModel> Create()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var model = JsonSerializer.Deserialize<IEnumerable<BaseModel>>(seedingRoom, options);
            return model;
        }
    }
}
