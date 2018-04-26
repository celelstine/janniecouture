using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace jannieCouture.Models
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AgeRange> AgeRange { get; set; }
        public DbSet<CartStatus> CartStatus { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CustomerFeedback> CustomerFeedback { get; set; }
        public DbSet<CustomerFeedbackResponse> CustomerFeedbackResponse { get; set; }
        public DbSet<CustomerFullfilment> CustomerFullfilment { get; set; }
        public DbSet<CustomerMaterial> CustomerMaterial { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddress { get; set; }
        public DbSet<DeliveryClass> DeliveryClass { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatus { get; set; }
        public DbSet<Demography> Demography { get; set; }
        public DbSet<FeedbackStatus> FeedbackStatus { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<MaterialCategory> MaterialCategory { get; set; }
        public DbSet<MeasurementCategory> MeasurementCategory { get; set; }
        public DbSet<MeasurementCategoryEntry> MeasurementCategoryEntry { get; set; }
        public DbSet<MeasurementEntry> MeasurementEntry { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderItemDeliveryAddress> OrderItemDeliveryAddress { get; set; }
        public DbSet<OrderItemMeasurement> OrderItemMeasurement { get; set; }
        public DbSet<OrderItemMeasurementDetail> OrderItemMeasurementDetail { get; set; }
        public DbSet<OrderPayment> OrderPayment { get; set; }
        public DbSet<OrderPaymentHistory> OrderPaymentHistory { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductDeliveryClass> ProductDeliveryClass { get; set; }
        public DbSet<ProductDemography> ProductDemography { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<ProductDetailPriceHistory> ProductDetailPriceHistory { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }
        public DbSet<RatedEntity> RatedEntity { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<SKU> SKU { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<SupplyPayment> SupplyPayment { get; set; }
        public DbSet<SupplyPaymentHistory> SupplyPaymentHistory { get; set; }
        public DbSet<SupplyReceived> SupplyReceived { get; set; }
        public DbSet<SupplyRequest> SupplyRequest { get; set; }
        public DbSet<SupplyRequestStatus> SupplyRequestStatus { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<UserLiveStream> UserLiveStream { get; set; }
        public DbSet<UserMeasurement> UserMeasurement { get; set; }
        public DbSet<UserMeasurementHistory> UserMeasurementHistory { get; set; }
        public DbSet<UserMeta> UserMeta { get; set; }
        public DbSet<UserSocialLink> UserSocialLink { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorFeedback> VendorFeedback { get; set; }
        public DbSet<VendorFeedbackResponse> VendorFeedbackResponse { get; set; }
	}
}
