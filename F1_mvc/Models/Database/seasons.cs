namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class seasons
    {
        [Key]
        [Display(Name = "Year")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int year { get; set; }

        [Required]
        [Display(Name = "URL")]
        [StringLength(255)]
        public string url { get; set; }
    }
}
