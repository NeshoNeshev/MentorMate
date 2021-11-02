using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MentorMate.Models;
using MentorMate.Models.InputModels;
using MentorMate.Models.ViewModels;
using MentorMate.Web.Factories;
using MentorMate.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MentorMate.Web.Pages
{

   

    public class IndexModel : PageModel
    {
        private const string path = "JsonFile/SeedingRoom.json";

        [DisplayName("Search by number of participants")]
        [BindProperty(SupportsGet = true), Range(1, int.MaxValue)]
        public int SearchByCount { get; set; }

        [DisplayName("Search by meeting duration")]
        [BindProperty(SupportsGet = true)]
        public Double SearchByDuration { get; set; }

        [DisplayName("Search By Date")]
        [BindProperty(SupportsGet = true), DataType(DataType.Date)]
        public DateTime SearchByDate { get; set; }

        [BindProperty]
        public string RoomName { get; set; }

        [BindProperty]
        public string Date { get; set; }

        private readonly IFactory<IEnumerable<BaseModel>> roomFactory;

        private readonly IRoomService service;

        public IEnumerable<BaseModel> BaseModels { get; private set; }

        public List<RoomViewModel> PageViewModel { get; set; }

        public IndexModel(IFactory<IEnumerable<BaseModel>> roomFactory, IRoomService service)
        {
            this.roomFactory = roomFactory;
            this.service = service;
        }
        public void OnGet(DateTime? searchByDate,
            int? searchByCount,
            int? searchByDuration)
        {

            this.PageViewModel = new List<RoomViewModel>();
            if (searchByCount != null && searchByDate != null && searchByDuration != null)
            {
                this.BaseModels = this.roomFactory.Create().ToList();
                this.PageViewModel = this.service.CreateRoomModel(this.BaseModels);
                if (!ModelState.IsValid)
                {
                    return;
                }
                this.PageViewModel = this.service.Search(this.PageViewModel, (DateTime)searchByDate, (int)searchByCount, (int)searchByDuration);

            }

        }

        public IActionResult OnPost(string date, string roomName)
        {
            var seedingRoom = System.IO.File.ReadAllText(path);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var model = date.Split("-");
            var fromDateAndTime = DateTime.Parse(model[0]).ToString("yyyy-MM-dd'T'HH:mm:ss");
            var toDateAndTime = DateTime.Parse(model[1]).ToString("yyyy-MM-dd'T'HH:mm:ss");


            var list = JsonConvert.DeserializeObject<List<BaseModel>>(seedingRoom);

            var element = list.FirstOrDefault(x => x.RoomName == roomName);
            if (element != null)
            {
                element.Schedule.Add(new ScheduleInputModel() { From = fromDateAndTime, To = toDateAndTime });
            }

            var modify = JsonConvert.SerializeObject(list, Formatting.Indented);

            Console.WriteLine(modify);
            System.IO.File.WriteAllText(path, modify);

            return RedirectToPage("/ThankYou");
        }
    }
}
