namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class circuits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public int circuitId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Reference")]
        public string circuitRef { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [StringLength(255)]
        [Display(Name = "Location")]
        public string location { get; set; }

        [StringLength(255)]
        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Latitude")]
        public double? lat { get; set; }

        [Display(Name = "Longitud")]
        public double? lng { get; set; }

        [Display(Name = "Altitude")]
        public int? alt { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "URL")]
        public string url { get; set; }
    }
}
