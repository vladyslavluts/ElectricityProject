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
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyTelephon> CompanyTelephons { get; set; }

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

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyNameFull)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.ReestrArendator)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.PositionManager)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Manager)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.LegalAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Edrpou)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.NumberPlat)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Svid)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.PostalAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.PostalIndex)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyTelephon>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<CompanyTelephon>()
                .Property(e => e.FullNumber)
                .IsUnicode(false);
        }
    }
}
