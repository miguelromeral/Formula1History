using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using F1_mvc.Models;

namespace F1_mvc.Models.GUI
{
    public class GrandPrixModel
    {
        public List<drivers> Drivers { get; private set; }

        public List<results> Results { get; private set; }

        public circuits Circuit { get; private set; }

        public races Race { get; private set; }
        
        public GrandPrixModel(int id, ref ModelF1 db)
        {
            Race = Queries.GetRaceByID(id, db);

            if (Race == null)
                return;

            Drivers = Queries.GetDriversInRace(id, db);
            Results = Queries.GetResultsInRace(id, db);
            
            //var q = from res in db.results
            //        join dri in db.drivers
            //        on res.driverId equals dri.driverId
            //        where res.raceId == id
            //        select dri;


            //var d = q.FirstOrDefault();
            //if (d != null)
            //{
            //    stats.Add("Winner", d);
            //}

        }

        [Display(Name = "Winner")]
        public drivers Winner { get { return GetDriverByPos(1); } }
        [Display(Name = "Second Place")]
        public drivers Second { get { return GetDriverByPos(2); } }
        [Display(Name = "Thrid Place")]
        public drivers Third { get { return GetDriverByPos(3); } }



        public drivers GetDriverByPos(int pos){
            return Queries.GetDriverInRaceByPos(Drivers, Results, pos);
        }


        public List<drivers> GetDriverOrderByRacePosition
        {
            get
            {
                var q = from dri in Drivers
                        join res in Results
                        on dri.driverId equals res.driverId
                        orderby res.positionOrder ascending
                        select dri;

                return q.ToList();
            }
        }
    }
}