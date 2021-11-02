# MentorMate Task

A ready-to-use for ASP.NET Core Web App / Razor pages, services, models factory, DI.

## Authors

- [Nesho Neshev](https://github.com/NeshoNeshev)


## Project Overview

### MentorMate.Models

**MentorMAte.Models** contains ViewModels, InputModels and BaseModel. For example:

- [BaseModel.cs](https://github.com/NeshoNeshev/MentorMate/blob/master/Models/MentorMate.Models/BaseModel.cs).
- [ScheduleInputModel.cs](https://github.com/NeshoNeshev/MentorMate/blob/master/Models/MentorMate.Models/InputModels/ScheduleInputModel.cs).
- [RoomViewModel.cs](https://github.com/NeshoNeshev/MentorMate/blob/master/Models/MentorMate.Models/ViewModels/RoomViewModel.cs).



### Services

- [RoomService.cs](https://github.com/NeshoNeshev/MentorMate/blob/master/Web/MentorMate.Web/Services/RoomService.cs).
- [ModifyDataService.cs](https://github.com/NeshoNeshev/MentorMate/blob/master/Web/MentorMate.Web/Services/ModifyDateService.cs).

#### Factory

[CreateRoomFactory.cs](https://github.com/NeshoNeshev/MentorMate/blob/master/Web/MentorMate.Web/Factories/CreateRoomFactory.cs) wil create room.
```csharp
namespace MentorMate.Web.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}

```

```csharp
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

```


