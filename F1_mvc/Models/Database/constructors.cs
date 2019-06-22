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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int constructorId { get; set; }

        [Required]
        [StringLength(255)]
        public string constructorRef { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string nationality { get; set; }

        [Required]
        [StringLength(255)]
        public string url { get; set; }
    }
}
