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
        
        public List<constructors> Constructors { get; private set; }

        public List<status> Statuses { get; private set; }

        public List<qualifying> Qualy { get; private set; }

        public GrandPrixModel(int id, ref ModelF1 db)
        {
            Race = Queries.GetRaceByID(id, db);

            if (Race == null)
                return;

            Drivers = Queries.GetDriversInRace(id, db);
            Results = Queries.GetResultsInRace(id, db);
            Constructors = Queries.GetConstructorsInRace(id, db);
            Statuses = Queries.GetStatusesInRace(Results, id, db);
            Qualy = Queries.GetQualyByRaceId(id, db);


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

        public drivers GetDriverById(int id)
        {
            return Drivers.Where(x => x.driverId == id).FirstOrDefault();
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

        public constructors GetConstructorsByDriverId(int id)
        {
            var q = from con in Constructors
                    join res in Results
                    on con.constructorId equals res.constructorId
                    where res.driverId == id
                    select con;

            return q.FirstOrDefault();
        }

        public results GetResultsByDriverId(int id)
        {
            var q = from res in Results
                    where res.driverId == id
                    select res;

            return q.FirstOrDefault();
        }

        public status GetStatusByDriverId(int id)
        {
            var q = from sta in Statuses
                    join res in Results
                    on sta.statusId equals res.statusId
                    where res.driverId == id
                    select sta;

            return q.FirstOrDefault();
        }
    }
}