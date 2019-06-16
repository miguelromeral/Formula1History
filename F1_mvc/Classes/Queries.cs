using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using F1_mvc.Models;

namespace F1_mvc.Classes
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

    }
}