using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Models.ViewModels
{
    public class PageViewModel
    {
        public PageViewModel()
        {
            this.RoomModel = new List<RoomViewModel>();
        }
        [Required]
        [Display(Name = "Search By Date")]
        [BindProperty]
        public DateTime? SearchByDate { get; set; }

        [Required]
        [Display(Name = "Search By Participants")]
        [BindProperty]
        public string SearchByParticipants { get; set; }

        [Required]
        [Display(Name = "Search By Duration")]
        [BindProperty]
        public int? SearchByDuration { get; set; }

        public List<RoomViewModel> RoomModel { get; set; }
    }
}
