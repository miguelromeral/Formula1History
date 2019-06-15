namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int statusId { get; set; }

        [Column("status")]
        [Required]
        [StringLength(255)]
        public string status1 { get; set; }
    }
}
