using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class TawredatDbContext : IdentityDbContext<ApplicationUser>
    {
        public TawredatDbContext()
        {
        }

        public TawredatDbContext(DbContextOptions<TawredatDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAboutApp> TbAboutApps { get; set; }
        public virtual DbSet<TbAddress> TbAddresses { get; set; }
        public virtual DbSet<TbCharge> TbCharges { get; set; }
        public virtual DbSet<TbCity> TbCities { get; set; }
        public virtual DbSet<TbComplainsAndSuggestion> TbComplainsAndSuggestions { get; set; }
        public virtual DbSet<TbDelivery> TbDeliveries { get; set; }
        public virtual DbSet<TbEvaluationDelivery> TbEvaluationDeliveries { get; set; }
        public virtual DbSet<TbEvaluationSupplierProduct> TbEvaluationSupplierProducts { get; set; }
        public virtual DbSet<TbFavourite> TbFavourites { get; set; }
        public virtual DbSet<TbNotification> TbNotifications { get; set; }
        public virtual DbSet<TbOffer> TbOffers { get; set; }
        public virtual DbSet<TbPaymentMethod> TbPaymentMethods { get; set; }
        public virtual DbSet<TbPoliciesAndPrivacy> TbPoliciesAndPrivacies { get; set; }
        public virtual DbSet<TbProduct> TbProducts { get; set; }
        public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }
        public virtual DbSet<TbPromocode> TbPromocodes { get; set; }
        public virtual DbSet<TbPurchasingCart> TbPurchasingCarts { get; set; }
        public virtual DbSet<TbSalesInvoice> TbSalesInvoices { get; set; }
        public virtual DbSet<TbSalesInvoiceProduct> TbSalesInvoiceProducts { get; set; }
        public virtual DbSet<TbSetting> TbSettings { get; set; }
        public virtual DbSet<TbSlider> TbSliders { get; set; }
        public virtual DbSet<TbSupplier> TbSuppliers { get; set; }
        public virtual DbSet<TbSupplierProduct> TbSupplierProducts { get; set; }
        public virtual DbSet<TbTermAndCondition> TbTermAndConditions { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAboutApp>(entity =>
            {
                entity.HasKey(e => e.AboutAppId);

                entity.ToTable("TbAboutApp");

                entity.Property(e => e.AboutAppId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AboutAppDescription).HasMaxLength(200);

                entity.Property(e => e.AboutAppForWhom).HasMaxLength(200);

                entity.Property(e => e.AboutAppTitle).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.ToTable("TbAddress");

                entity.Property(e => e.AddressId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressArea).HasMaxLength(200);

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AddressCountry).HasMaxLength(200);

                entity.Property(e => e.AddressLatitude).HasMaxLength(200);

                entity.Property(e => e.AddressStreet).HasMaxLength(200);

                entity.Property(e => e.Addresslongitude).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.MainAddress).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.Otp)
                    .HasMaxLength(200)
                    .HasColumnName("OTP");

                entity.Property(e => e.PhoneNumber).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCharge>(entity =>
            {
                entity.HasKey(e => e.ChargeId);

                entity.ToTable("TbCharge");

                entity.Property(e => e.ChargeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ChargeType).HasMaxLength(200);

                entity.Property(e => e.ChargeValue).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("TbCity");

                entity.Property(e => e.CityId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CityName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbComplainsAndSuggestion>(entity =>
            {
                entity.HasKey(e => e.ComplaintsAndSuggestionsId);

                entity.ToTable("TbComplainsAndSuggestion");

                entity.Property(e => e.ComplaintsAndSuggestionsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ComplaintsAndSuggestionsText).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbDelivery>(entity =>
            {
                entity.HasKey(e => e.DeliveryManId);

                entity.ToTable("TbDelivery");

                entity.Property(e => e.DeliveryManId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeliveryManAreaName).HasMaxLength(200);

                entity.Property(e => e.DeliveryManCityName).HasMaxLength(200);

                entity.Property(e => e.DeliveryManEvaluationNumber).HasMaxLength(200);

                entity.Property(e => e.DeliveryManEvaluationStarts).HasMaxLength(200);

                entity.Property(e => e.DeliveryManName).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEvaluationDelivery>(entity =>
            {
                entity.HasKey(e => e.DeliveryEvaluationId);

                entity.ToTable("TbEvaluationDelivery");

                entity.Property(e => e.DeliveryEvaluationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeliveryEvaluationText).HasMaxLength(200);

                entity.Property(e => e.DeliveryName).HasMaxLength(200);

                entity.Property(e => e.EvaluaterId).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.StartsNo).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEvaluationSupplierProduct>(entity =>
            {
                entity.HasKey(e => e.SupplierProductEvaluationId);

                entity.ToTable("TbEvaluationSupplierProduct");

                entity.Property(e => e.SupplierProductEvaluationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EvaluaterId).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.StartsNo).HasMaxLength(200);

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.SupplierProductEevaluationText)
                    .HasMaxLength(200)
                    .HasColumnName("SupplierProductEEvaluationText");

                entity.Property(e => e.ToBeEvaluatedId).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFavourite>(entity =>
            {
                entity.HasKey(e => e.FavouritesId);

                entity.Property(e => e.FavouritesId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationNumber).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationStarts).HasMaxLength(200);

                entity.Property(e => e.ProductImage).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductPrice).HasMaxLength(200);

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbNotification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.ToTable("TbNotification");

                entity.Property(e => e.NotificationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.NotificationType).HasMaxLength(200);

                entity.Property(e => e.SenderId).HasMaxLength(200);

                entity.Property(e => e.SenderName).HasMaxLength(200);

                entity.Property(e => e.Text).HasMaxLength(200);

                entity.Property(e => e.ToWhomId).HasMaxLength(200);

                entity.Property(e => e.ToWhomName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbOffer>(entity =>
            {
                entity.HasKey(e => e.OfferId);

                entity.ToTable("TbOffer");

                entity.Property(e => e.OfferId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PriceAfterOffer).HasMaxLength(200);

                entity.Property(e => e.PriceBeforeOffer).HasMaxLength(200);

                entity.Property(e => e.ProductCategoryName).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationNumber).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationStarts).HasMaxLength(200);

                entity.Property(e => e.ProductImage).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId);

                entity.ToTable("TbPaymentMethod");

                entity.Property(e => e.PaymentMethodId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PaymentMethodDescription).HasMaxLength(200);

                entity.Property(e => e.PaymentMethodName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPoliciesAndPrivacy>(entity =>
            {
                entity.HasKey(e => e.PoliciesAndPrivacyId);

                entity.ToTable("TbPoliciesAndPrivacy");

                entity.Property(e => e.PoliciesAndPrivacyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyDescription).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyForWhom).HasMaxLength(200);

                entity.Property(e => e.PoliciesAndPrivacyTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("TbProduct");

                entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DiscountPercent).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProductCategoryName).HasMaxLength(200);

                entity.Property(e => e.ProductDescription).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductNewPrice).HasMaxLength(200);

                entity.Property(e => e.ProductPrice).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryId);

                entity.ToTable("TbProductCategory");

                entity.Property(e => e.ProductCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProductCategoryDescription).HasMaxLength(200);

                entity.Property(e => e.ProductCategoryImage).HasMaxLength(200);

                entity.Property(e => e.ProductCategoryName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPromocode>(entity =>
            {
                entity.HasKey(e => e.PromocodeId);

                entity.ToTable("TbPromocode");

                entity.Property(e => e.PromocodeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PromocodeDiscountPercent).HasMaxLength(200);

                entity.Property(e => e.PromocodeTitle).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPurchasingCart>(entity =>
            {
                entity.HasKey(e => e.PurchasingCartId);

                entity.ToTable("TbPurchasingCart");

                entity.Property(e => e.PurchasingCartId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DiscountPercent).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationNumber).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationStarts).HasMaxLength(200);

                entity.Property(e => e.ProductImage).HasMaxLength(200);

                entity.Property(e => e.ProductMaximumSale).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductPrice).HasMaxLength(200);

                entity.Property(e => e.ProductPriceAfterDiscount).HasMaxLength(200);

                entity.Property(e => e.Promocode).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSalesInvoice>(entity =>
            {
                entity.HasKey(e => e.SalesInvoiceId);

                entity.ToTable("TbSalesInvoice");

                entity.Property(e => e.SalesInvoiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(200);

                entity.Property(e => e.DeliveryManName).HasMaxLength(200);

                entity.Property(e => e.DeliveryStatus).HasMaxLength(200);

                entity.Property(e => e.DelivryDate).HasMaxLength(200);

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PaymnetMethodName).HasMaxLength(200);

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.TotalInvoiceValue).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSalesInvoiceProduct>(entity =>
            {
                entity.HasKey(e => e.SalesInvoiceProductId);

                entity.ToTable("TbSalesInvoiceProduct");

                entity.Property(e => e.SalesInvoiceProductId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(200);

                entity.Property(e => e.DeliveryManName).HasMaxLength(200);

                entity.Property(e => e.DeliveryStatus).HasMaxLength(200);

                entity.Property(e => e.DelivryDate).HasMaxLength(200);

                entity.Property(e => e.DiscountPercent).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PaymnetMethodName).HasMaxLength(200);

                entity.Property(e => e.ProductCategoryName).HasMaxLength(200);

                entity.Property(e => e.ProductImage).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductPrice).HasMaxLength(200);

                entity.Property(e => e.ProductPriceAfterDiscount).HasMaxLength(200);

                entity.Property(e => e.ProductQty).HasMaxLength(200);

                entity.Property(e => e.Promocode).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.TotalProductValue).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("TbSetting");

                entity.Property(e => e.SettingId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueAddedTax).HasMaxLength(200);
            });

            modelBuilder.Entity<TbSlider>(entity =>
            {
                entity.HasKey(e => e.SliderId);

                entity.ToTable("TbSlider");

                entity.Property(e => e.SliderId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SliderImage).HasMaxLength(200);

                entity.Property(e => e.SliderLocation).HasMaxLength(200);

                entity.Property(e => e.SliderText).HasMaxLength(200);

                entity.Property(e => e.SliderTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("TbSupplier");

                entity.Property(e => e.SupplierId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomersNumber).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.SupplierCityName).HasMaxLength(200);

                entity.Property(e => e.SupplierEvaluationNumber).HasMaxLength(200);

                entity.Property(e => e.SupplierEvaluationStars).HasMaxLength(200);

                entity.Property(e => e.SupplierImage).HasMaxLength(200);

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSupplierProduct>(entity =>
            {
                entity.HasKey(e => e.SupplierProductId);

                entity.ToTable("TbSupplierProduct");

                entity.Property(e => e.SupplierProductId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(getdate())")
                    .IsFixedLength(true);

                entity.Property(e => e.CurrentState)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.Notes)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ProductCategoryName).HasMaxLength(200);

                entity.Property(e => e.ProductDescription).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationNumber).HasMaxLength(200);

                entity.Property(e => e.ProductEvaluationStars).HasMaxLength(200);

                entity.Property(e => e.ProductImage).HasMaxLength(200);

                entity.Property(e => e.ProductMaximumSaleQty).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductPrice).HasMaxLength(200);

                entity.Property(e => e.SupplierCityName).HasMaxLength(200);

                entity.Property(e => e.SupplierName).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TbTermAndCondition>(entity =>
            {
                entity.HasKey(e => e.TermsAndConditionsId);

                entity.ToTable("TbTermAndCondition");

                entity.Property(e => e.TermsAndConditionsId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentState).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.TermsAndConditionsDescription).HasMaxLength(200);

                entity.Property(e => e.TermsAndConditionsForWhom).HasMaxLength(200);

                entity.Property(e => e.TermsAndConditionsTitle).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
