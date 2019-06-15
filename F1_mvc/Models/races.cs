namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class races
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int raceId { get; set; }

        public int year { get; set; }

        public int round { get; set; }

        public int circuitId { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public TimeSpan? time { get; set; }

        [StringLength(255)]
        public string url { get; set; }
    }
}
