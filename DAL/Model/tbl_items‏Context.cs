using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Model
{
    public partial class tbl_items‏Context : DbContext
    {
        public tbl_items‏Context()
        {
        }

        public tbl_items‏Context(DbContextOptions<tbl_items‏Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GBRPOLT\\SQLEXPRESS;Database=tbl_items‏;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("items");

                entity.Property(e => e.Discount)
                    .IsRequired()
                    .HasColumnName("discount");

                entity.Property(e => e.Editable)
                    .IsRequired()
                    .HasColumnName("editable");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.NewPrice).HasColumnName("newPrice");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price");

                entity.Property(e => e.Supplier)
                    .IsRequired()
                    .HasColumnName("supplier");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
