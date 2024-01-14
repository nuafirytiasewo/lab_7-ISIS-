using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace lab_7.Models
{
    public partial class ADOModelDB : DbContext
    {
        public ADOModelDB()
            : base("name=ADOModelDB")
        {
        }

        public virtual DbSet<Building_materials> Building_materials { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Evaluation_criteria> Evaluation_criteria { get; set; }
        public virtual DbSet<Evaluations> Evaluations { get; set; }
        public virtual DbSet<Real_estate_objects> Real_estate_objects { get; set; }
        public virtual DbSet<Realtor> Realtor { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building_materials>()
                .Property(e => e.Material_name)
                .IsUnicode(false);

            modelBuilder.Entity<Building_materials>()
                .HasMany(e => e.Real_estate_objects)
                .WithOptional(e => e.Building_materials)
                .HasForeignKey(e => e.Building_material);

            modelBuilder.Entity<Districts>()
                .Property(e => e.District_name)
                .IsUnicode(false);

            modelBuilder.Entity<Districts>()
                .HasMany(e => e.Real_estate_objects)
                .WithOptional(e => e.Districts)
                .HasForeignKey(e => e.District);

            modelBuilder.Entity<Evaluation_criteria>()
                .Property(e => e.Criteria_name)
                .IsUnicode(false);

            modelBuilder.Entity<Real_estate_objects>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Real_estate_objects>()
                .Property(e => e.Object_description)
                .IsUnicode(false);

            modelBuilder.Entity<Realtor>()
                .Property(e => e.Last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Realtor>()
                .Property(e => e.First_name)
                .IsUnicode(false);

            modelBuilder.Entity<Realtor>()
                .Property(e => e.Middle_name)
                .IsUnicode(false);

            modelBuilder.Entity<Realtor>()
                .Property(e => e.Contact_phone)
                .IsUnicode(false);
        }
    }
}
