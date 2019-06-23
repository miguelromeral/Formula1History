using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F1_mvc.Models.GUI
{
    public class CircuitModel
    {
        public circuits Circuit { get; set; }

        [Display(Name = "Track Record")]
        public lapTimes TrackRecord { get; set; }
    }
}