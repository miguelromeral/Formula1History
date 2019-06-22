namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class constructors
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int constructorId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Reference")]
        public string constructorRef { get; set; }

        [Required]
        [Display(Name = "Constructor")]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        [Display(Name = "Nationality")]
        public string nationality { get; set; }

        [Required]
        [Display(Name = "URL")]
        [StringLength(255)]
        public string url { get; set; }
    }
}
