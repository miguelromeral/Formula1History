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
        public int driverId { get; set; }

        [Required]
        [StringLength(255)]
        public string driverRef { get; set; }

        public int? number { get; set; }

        [StringLength(3)]
        public string code { get; set; }

        [Required]
        [StringLength(255)]
        public string forename { get; set; }

        [Required]
        [StringLength(255)]
        public string surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dob { get; set; }

        [StringLength(255)]
        public string nationality { get; set; }

        [Required]
        [StringLength(255)]
        public string url { get; set; }
    }
}
