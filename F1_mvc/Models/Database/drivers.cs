namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class drivers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public int driverId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Reference")]
        public string driverRef { get; set; }

        [Display(Name = "Number")]
        public int? number { get; set; }

        [StringLength(3)]
        [Display(Name = "Short name")]
        public string code { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Forename")]
        public string forename { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Surname")]
        public string surname { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Birth date")]
        public DateTime? dob { get; set; }

        [StringLength(255)]
        [Display(Name = "Nationality")]
        public string nationality { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Url")]
        public string url { get; set; }
    }
}
