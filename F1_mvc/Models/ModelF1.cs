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

        public virtual DbSet<circuits> circuits { get; set; }
        public virtual DbSet<constructorResults> constructorResults { get; set; }
        public virtual DbSet<constructors> constructors { get; set; }
        public virtual DbSet<constructorStandings> constructorStandings { get; set; }
        public virtual DbSet<drivers> drivers { get; set; }
        public virtual DbSet<driverStandings> driverStandings { get; set; }
        public virtual DbSet<lapTimes> lapTimes { get; set; }
        public virtual DbSet<pitStops> pitStops { get; set; }
        public virtual DbSet<qualifying> qualifying { get; set; }
        public virtual DbSet<races> races { get; set; }
        public virtual DbSet<results> results { get; set; }
        public virtual DbSet<seasons> seasons { get; set; }
        public virtual DbSet<status> status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<circuits>()
                .Property(e => e.circuitRef)
                .IsUnicode(false);

            modelBuilder.Entity<circuits>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<circuits>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<circuits>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<circuits>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<constructorResults>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<constructors>()
                .Property(e => e.constructorRef)
                .IsUnicode(false);

            modelBuilder.Entity<constructors>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<constructors>()
                .Property(e => e.nationality)
                .IsUnicode(false);

            modelBuilder.Entity<constructors>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<constructorStandings>()
                .Property(e => e.positionText)
                .IsUnicode(false);

            modelBuilder.Entity<drivers>()
                .Property(e => e.driverRef)
                .IsUnicode(false);

            modelBuilder.Entity<drivers>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<drivers>()
                .Property(e => e.forename)
                .IsUnicode(false);

            modelBuilder.Entity<drivers>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<drivers>()
                .Property(e => e.nationality)
                .IsUnicode(false);

            modelBuilder.Entity<drivers>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<driverStandings>()
                .Property(e => e.positionText)
                .IsUnicode(false);

            modelBuilder.Entity<lapTimes>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<pitStops>()
                .Property(e => e.duration)
                .IsUnicode(false);

            modelBuilder.Entity<qualifying>()
                .Property(e => e.q1)
                .IsUnicode(false);

            modelBuilder.Entity<qualifying>()
                .Property(e => e.q2)
                .IsUnicode(false);

            modelBuilder.Entity<qualifying>()
                .Property(e => e.q3)
                .IsUnicode(false);

            modelBuilder.Entity<races>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<races>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<results>()
                .Property(e => e.positionText)
                .IsUnicode(false);

            modelBuilder.Entity<results>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<results>()
                .Property(e => e.fastestLapTime)
                .IsUnicode(false);

            modelBuilder.Entity<results>()
                .Property(e => e.fastestLapSpeed)
                .IsUnicode(false);

            modelBuilder.Entity<seasons>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<status>()
                .Property(e => e.status1)
                .IsUnicode(false);
        }
    }
}
