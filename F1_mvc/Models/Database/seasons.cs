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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int year { get; set; }

        [Required]
        [StringLength(255)]
        public string url { get; set; }
    }
}
