namespace ElectricityProject.DataLayer.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<AddressPlan> AddressPlans { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<StreetPrefix> StreetPrefixes { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }
        public virtual DbSet<TypeBuilding> TypeBuildings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressPlan>()
                .Property(e => e.CodePostal)
                .IsUnicode(false);

            modelBuilder.Entity<AddressPlan>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.AddressPlan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.Balanse)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Building>()
                .Property(e => e.Iznos)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.AddressPlans)
                .WithRequired(e => e.Street)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StreetPrefix>()
                .HasMany(e => e.Streets)
                .WithRequired(e => e.StreetPrefix)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeBuilding>()
                .HasMany(e => e.Buildings)
                .WithRequired(e => e.TypeBuilding)
                .WillCascadeOnDelete(false);
        }
    }
}
