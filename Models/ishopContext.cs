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

        public virtual DbSet<Domain> Domain { get; set; }
        public virtual DbSet<DomainCustomer> DomainCustomer { get; set; }
        public virtual DbSet<IshopBusinessSetting> IshopBusinessSetting { get; set; }
        public virtual DbSet<IshopCategory> IshopCategory { get; set; }
        public virtual DbSet<IshopProdImgGallery> IshopProdImgGallery { get; set; }
        public virtual DbSet<IshopProdPricing> IshopProdPricing { get; set; }
        public virtual DbSet<IshopProdVariant> IshopProdVariant { get; set; }
        public virtual DbSet<IshopProduct> IshopProduct { get; set; }
        public virtual DbSet<IshopSystemUser> IshopSystemUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ishop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Domain>(entity =>
            {
                entity.ToTable("domain");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Domain1)
                    .IsRequired()
                    .HasColumnName("domain")
                    .HasMaxLength(50);

                entity.Property(e => e.DomainExpiryDate)
                    .HasColumnName("domain_expiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.DomainRegDate)
                    .HasColumnName("domain_reg_date")
                    .HasColumnType("date");

                entity.Property(e => e.OnlineDb)
                    .IsRequired()
                    .HasColumnName("online_db")
                    .HasMaxLength(100);

                entity.Property(e => e.OnlinePass)
                    .IsRequired()
                    .HasColumnName("online_pass")
                    .HasMaxLength(50);

                entity.Property(e => e.OnlineUs)
                    .IsRequired()
                    .HasColumnName("online_us")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DomainCustomer>(entity =>
            {
                entity.ToTable("domain_customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerAddresss).HasColumnName("customer_addresss");

                entity.Property(e => e.CustomerCompany)
                    .HasColumnName("customer_company")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerContactNo)
                    .IsRequired()
                    .HasColumnName("customer_contact_no")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasColumnName("customer_email")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customer_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IshopBusinessSetting>(entity =>
            {
                entity.ToTable("ishop_business_setting");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessAddressFactory)
                    .HasColumnName("business_address_factory")
                    .HasMaxLength(250);

                entity.Property(e => e.BusinessAddressOffice)
                    .IsRequired()
                    .HasColumnName("business_address_office")
                    .HasMaxLength(250);

                entity.Property(e => e.BusinessCellNo)
                    .HasColumnName("business_cell_no")
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessCopyRight).HasColumnName("business_copy_right");

                entity.Property(e => e.BusinessEmail)
                    .IsRequired()
                    .HasColumnName("business_email")
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessEmailReceived)
                    .IsRequired()
                    .HasColumnName("business_email_received")
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessFaxNo)
                    .HasColumnName("business_fax_no")
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasColumnName("business_name")
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessOwnerName)
                    .HasColumnName("business_owner_name")
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessPhoneNo)
                    .IsRequired()
                    .HasColumnName("business_phone_no")
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessTitle)
                    .IsRequired()
                    .HasColumnName("business_title")
                    .HasMaxLength(50);

                entity.Property(e => e.DomainId).HasColumnName("domain_id");
            });

            modelBuilder.Entity<IshopCategory>(entity =>
            {
                entity.ToTable("ishop_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CatDetail).HasColumnName("cat_detail");

                entity.Property(e => e.CatFeatureImg)
                    .HasColumnName("cat_feature_img")
                    .HasMaxLength(50);

                entity.Property(e => e.CatKeywords)
                    .HasColumnName("cat_keywords")
                    .HasMaxLength(50);

                entity.Property(e => e.CatMetatag)
                    .HasColumnName("cat_metatag")
                    .HasMaxLength(100);

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasColumnName("cat_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CatPermalink)
                    .IsRequired()
                    .HasColumnName("cat_permalink")
                    .HasMaxLength(100);

                entity.Property(e => e.CatPic2)
                    .HasColumnName("cat_pic_2")
                    .HasMaxLength(50);

                entity.Property(e => e.CatShortDetail)
                    .HasColumnName("cat_short_detail")
                    .HasMaxLength(150);

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasMaxLength(50);

                entity.Property(e => e.GoogleCategory)
                    .HasColumnName("google_category")
                    .HasMaxLength(50);

                entity.Property(e => e.IsFeature).HasColumnName("is_feature");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Ranking).HasColumnName("ranking");

                entity.Property(e => e.ShowFooter).HasColumnName("show_footer");

                entity.Property(e => e.ShowHome).HasColumnName("show_home");

                entity.Property(e => e.ShowMenu).HasColumnName("show_menu");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<IshopProdImgGallery>(entity =>
            {
                entity.ToTable("ishop_prod_img_gallery");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("img_url")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");
            });

            modelBuilder.Entity<IshopProdPricing>(entity =>
            {
                entity.ToTable("ishop_prod_pricing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CostPrice).HasColumnName("cost_price");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            });

            modelBuilder.Entity<IshopProdVariant>(entity =>
            {
                entity.ToTable("ishop_prod_variant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.VariantDetail).HasColumnName("variant_detail");

                entity.Property(e => e.VariantFeatureImg)
                    .IsRequired()
                    .HasColumnName("variant_feature_img")
                    .HasMaxLength(50);

                entity.Property(e => e.VariantPic2)
                    .HasColumnName("variant_pic_2")
                    .HasMaxLength(50);

                entity.Property(e => e.VariantShortDesc)
                    .HasColumnName("variant_short_desc")
                    .HasMaxLength(250);

                entity.Property(e => e.VariantTitle)
                    .HasColumnName("variant_title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IshopProduct>(entity =>
            {
                entity.ToTable("ishop_product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasMaxLength(50);

                entity.Property(e => e.GoogleCateory)
                    .HasColumnName("google_cateory")
                    .HasMaxLength(50);

                entity.Property(e => e.HitUrl).HasColumnName("hit_url");

                entity.Property(e => e.IsFeature).HasColumnName("is_feature");

                entity.Property(e => e.IsSpecial).HasColumnName("is_special");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasColumnName("item_code")
                    .HasMaxLength(50);

                entity.Property(e => e.ProPic2)
                    .HasColumnName("pro_pic_2")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdDetail).HasColumnName("prod_detail");

                entity.Property(e => e.ProdFeatureImg)
                    .IsRequired()
                    .HasColumnName("prod_feature_img")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdKeywords)
                    .HasColumnName("prod_keywords")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdMetaKeyword)
                    .HasColumnName("prod_meta_keyword")
                    .HasMaxLength(100);

                entity.Property(e => e.ProdMetaTitle)
                    .IsRequired()
                    .HasColumnName("prod_meta_title")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasColumnName("prod_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdPermalink)
                    .IsRequired()
                    .HasColumnName("prod_permalink")
                    .HasMaxLength(100);

                entity.Property(e => e.ProdShortDetail)
                    .HasColumnName("prod_short_detail")
                    .HasMaxLength(250);

                entity.Property(e => e.Ranking).HasColumnName("ranking");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<IshopSystemUser>(entity =>
            {
                entity.ToTable("ishop_system_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasMaxLength(50);

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasMaxLength(50);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasMaxLength(50);

                entity.Property(e => e.SuEmail)
                    .IsRequired()
                    .HasColumnName("su_email")
                    .HasMaxLength(50);

                entity.Property(e => e.SuPassword)
                    .IsRequired()
                    .HasColumnName("su_password")
                    .HasMaxLength(50);

                entity.Property(e => e.SuProfilePic)
                    .HasColumnName("su_profile_pic")
                    .HasMaxLength(50);

                entity.Property(e => e.SuRole)
                    .IsRequired()
                    .HasColumnName("su_role")
                    .HasMaxLength(50);

                entity.Property(e => e.SuStatus).HasColumnName("su_status");

                entity.Property(e => e.SuUsername)
                    .IsRequired()
                    .HasColumnName("su_username")
                    .HasMaxLength(50);
            });
        }
    }
}
