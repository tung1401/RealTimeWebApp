using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RealTimeWebApp.Models
{
    public partial class MyMapContext : DbContext
    {
        public MyMapContext()
        {
        }

        public MyMapContext(DbContextOptions<MyMapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LocationMap> LocationMap { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MyMap;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<LocationMap>(entity =>
            {
                entity.Property(e => e.Latitude).HasMaxLength(50);
                entity.Property(e => e.Longitude).HasMaxLength(50);
            });
        }
    }
}
