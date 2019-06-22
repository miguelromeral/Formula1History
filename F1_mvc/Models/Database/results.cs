namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class results
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int resultId { get; set; }

        public int raceId { get; set; }

        public int driverId { get; set; }

        public int constructorId { get; set; }

        public int? number { get; set; }

        public int grid { get; set; }

        public int? position { get; set; }

        [Required]
        [StringLength(255)]
        public string positionText { get; set; }

        public int positionOrder { get; set; }

        public double points { get; set; }

        public int laps { get; set; }

        [StringLength(255)]
        public string time { get; set; }

        public int? milliseconds { get; set; }

        public int? fastestLap { get; set; }

        public int? rank { get; set; }

        [StringLength(255)]
        public string fastestLapTime { get; set; }

        [StringLength(255)]
        public string fastestLapSpeed { get; set; }

        public int statusId { get; set; }
    }
}
