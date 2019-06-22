namespace F1_mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class constructorResults
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int constructorResultsId { get; set; }

        public int raceId { get; set; }

        public int constructorId { get; set; }

        public double? points { get; set; }

        [StringLength(255)]
        public string status { get; set; }
    }
}
