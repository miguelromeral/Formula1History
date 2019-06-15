namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class driverStandings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int driverStandingsId { get; set; }

        public int raceId { get; set; }

        public int driverId { get; set; }

        public double points { get; set; }

        public int? position { get; set; }

        [StringLength(255)]
        public string positionText { get; set; }

        public int wins { get; set; }
    }
}
