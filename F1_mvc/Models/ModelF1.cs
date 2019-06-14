namespace F1_mvc.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelF1 : DbContext
    {
        public ModelF1()
            : base("name=ModelF1")
        {
        }

        public virtual DbSet<seasons> seasons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
