namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qualifying")]
    public partial class qualifying
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int qualifyId { get; set; }

        public int raceId { get; set; }

        public int driverId { get; set; }

        public int constructorId { get; set; }

        public int number { get; set; }

        public int? position { get; set; }

        [StringLength(255)]
        public string q1 { get; set; }

        [StringLength(255)]
        public string q2 { get; set; }

        [StringLength(255)]
        public string q3 { get; set; }
    }
}
