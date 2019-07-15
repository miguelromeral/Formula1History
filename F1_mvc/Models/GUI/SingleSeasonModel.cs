using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F1_mvc.Models.GUI
{
    public class SingleSeasonModel
    {
        public seasons Season{ get; set; }

        [Display(Name = "Driver Champion")]
        public drivers DriverChampion { get; set; }
    }
}