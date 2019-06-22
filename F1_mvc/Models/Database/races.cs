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
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int raceId { get; set; }

        [Display(Name = "Year")]
        public int year { get; set; }

        [Display(Name = "Round")]
        public int round { get; set; }

        [Display(Name = "Circuit ID")]
        public int circuitId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Grand Prix")]
        public string name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Display(Name = "Time")]
        public TimeSpan? time { get; set; }

        [StringLength(255)]
        [Display(Name = "Url")]
        public string url { get; set; }
    }
}
