using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using F1_mvc.Models;

namespace F1_mvc.Models.GUI
{
    public class DriverModel
    {
        public drivers Driver { get; set; }

        public int Seasons { get; set; }

        public int Races { get; set; }

        public int Poles { get; set; }

        public int FastestLaps { get; set; }

        public int Wins { get; set; }

        public int Championships { get; set; }


        public string GetDriverFullname()
        {
            if (Driver == null)
                return "Unknown";
            return Driver.forename + " " + Driver.surname;
        }
    }
}