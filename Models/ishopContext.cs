using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ishop.Models
{
    public partial class ishopContext : DbContext
    {
        public ishopContext()
        {
        }

        public ishopContext(DbContextOptions<ishopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SystemUser> SystemUser { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server= localhost\\SQLEXPRESS01;Database=ishop;Trusted_Connection=True;User ID=; Password=;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasMaxLength(50);

                entity.Property(e => e.CatKeywords)
                    .HasColumnName("cat_keywords")
                    .HasMaxLength(50);

                entity.Property(e => e.CatName)
                    .HasColumnName("cat_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CatPic)
                    .HasColumnName("cat_pic")
                    .HasMaxLength(50);

                entity.Property(e => e.CatStatus)
                    .HasColumnName("cat_status")
                    .HasMaxLength(50);

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasMaxLength(50);

                entity.Property(e => e.CostPrice)
                    .HasColumnName("cost_price")
                    .HasMaxLength(50);

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .HasColumnName("item_code")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdDescription)
                    .HasColumnName("prod_description")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdKeywords)
                    .HasColumnName("prod_keywords")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdName)
                    .HasColumnName("prod_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdStatus)
                    .HasColumnName("prod_status")
                    .HasMaxLength(50);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasMaxLength(50);

                entity.Property(e => e.SalePrice)
                    .HasColumnName("sale_price")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.ToTable("system_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasMaxLength(50);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasMaxLength(50);

                entity.Property(e => e.SuPassword)
                    .HasColumnName("su_password")
                    .HasMaxLength(50);

                entity.Property(e => e.SuProfilePic)
                    .HasColumnName("su_profile_pic")
                    .HasMaxLength(50);

                entity.Property(e => e.SuRole)
                    .HasColumnName("su_role")
                    .HasMaxLength(50);

                entity.Property(e => e.SuStatus)
                    .HasColumnName("su_status")
                    .HasMaxLength(50);

                entity.Property(e => e.SuUsername)
                    .HasColumnName("su_username")
                    .HasMaxLength(50);
            });
        }
    }
}
