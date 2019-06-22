using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using F1_mvc.Models;

namespace F1_mvc.Classes
{
    public static class Utilities
    {
        public static string Fullname(drivers driver)
        {
            if (driver == null)
                return "";

            return driver.forename + " " + driver.surname;
        }
    }
}