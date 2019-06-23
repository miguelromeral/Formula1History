using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using F1_mvc.Models;
using F1_mvc.Classes;

namespace F1_mvc.Models
{
    public static class Queries
    {
        public static int GetSeasonsCount(ModelF1 db, int id)
        {
            var s = String.Format(
                @"select count(*)
                    from driverStandings
                    inner join (
                        select max(raceId) as raceId, year
                        from races
                        group by year
                    ) as A on driverStandings.raceId = A.raceId
                    where driverId = {0}"
                , id);

            return db.Database.SqlQuery<int>(s).FirstOrDefault();
        }

        public static int GetRacesCount(ModelF1 db, int driverId)
        {
            return db.results.Where(x => x.driverId == driverId).Count();
        }


        public static int GetChampionshipCount(ModelF1 db, int id)
        {
            var s = String.Format(
                @"select count(*)
                    from driverStandings
                    inner join (
                        select max(raceId) as raceId, year
                        from races
                        group by year
                    ) as A on driverStandings.raceId = A.raceId
                    where driverId = {0}
                    and driverStandings.position = 1"
                , id);

            return db.Database.SqlQuery<int>(s).FirstOrDefault();
        }

        
        public static int GetFastestLapCount(ModelF1 db, int id)
        {
            var s = String.Format(
                @"select count(*)
                    from (
	                    select MIN(time) as 'fastest', raceId
                        from lapTimes
                        where driverId = {0}
                        group by raceId
                    ) as mine
                    inner join(
                        select MIN(time) as 'fastest', raceId
                        from lapTimes
                        group by raceId
                    ) as whole
                    on mine.fastest = whole.fastest"
                , id);

            return db.Database.SqlQuery<int>(s).FirstOrDefault();
        }




        public static races GetRaceByID(int? id, ModelF1 db)
        {
            if (id == null)
                return null;
            
            return db.races.Where(x => x.raceId == id).FirstOrDefault();
        }

        public static List<drivers> GetDriversInRace(int id, ModelF1 db)
        {
            var q = from dri in db.drivers
                    join res in db.results
                    on dri.driverId equals res.driverId
                    where res.raceId == id
                    select dri;

            return q.ToList();
        }


        public static List<results> GetResultsInRace(int id, ModelF1 db)
        {
            var q = from res in db.results
                    where res.raceId == id
                    select res;

            return q.ToList();
        }

        public static List<constructors> GetConstructorsInRace(int id, ModelF1 db)
        {
            var q = (from res in db.results
                    join con in db.constructors
                    on res.constructorId equals con.constructorId
                    where res.raceId == id
                    select con).Distinct();

            return q.ToList();
        }


        public static drivers GetDriverInRaceByPos(List<drivers> drivers, List<results> results, int pos)
        {
            var q = from dri in drivers
                    join res in results
                    on dri.driverId equals res.driverId
                    where res.position == pos
                    select dri;

            return q.FirstOrDefault();
        }

        public static List<status> GetStatusesInRace(List<results> results, int id, ModelF1 db)
        {
            var q = (from res in results
                     join sta in db.status
                     on res.statusId equals sta.statusId
                     where res.raceId == id
                     select sta).Distinct();

            return q.ToList();
        }



        public static constructors GetConstructorsById(string reference, ModelF1 db)
        {
            return db.constructors.Where(x => x.constructorRef == reference).FirstOrDefault();
        }

        public static List<races> GetRacesByConstructorId(int id, ModelF1 db)
        {
            return db.races.Join(db.results,
                ra => ra.raceId,
                re => re.raceId,
                (ra, re) => new { ra, re.constructorId })
                .Where(x => x.constructorId == id).Select(x => x.ra).Distinct()
                .OrderBy(x => x.year).ThenBy(x => x.round).ToList();
        }

        public static List<races> GetRacesByConstructorId(string id, ModelF1 db)
        {
            return GetRacesByConstructorId(db.constructors.Where(x => x.constructorRef == id)
                .Select(x => x.constructorId).FirstOrDefault(), db);
        }

        public static List<qualifying> GetQualyByRaceId(int id, ModelF1 db)
        {
            return db.qualifying.Where(x => x.raceId == id).OrderBy(x => x.position).ToList();
        }

        public static lapTimes GetTrackRecordCircuit(int id, ModelF1 db)
        {
            var q = from lap in db.lapTimes
                    join rac in db.races
                    on lap.raceId equals rac.raceId
                    join cir in db.circuits
                    on rac.circuitId equals cir.circuitId
                    where cir.circuitId == id
                    orderby lap.milliseconds
                    select lap;

            return q.FirstOrDefault();
        }
    }
}