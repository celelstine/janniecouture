using System;
using System.ComponentModel;
using System.Globalization;
namespace jannieCouture.Models
{
    public class ProductDetailPriceHistory
    {
        public ProductDetailPriceHistory()
        {
        }
		public int ProductDetailPriceHistoryId { get; set; }
		public double Price { get; set; }
		public ProductDetail ProductDetail { get; set; }
        public ProductDetailPrice ProductDetailPriceId { get; set; }
		public string Currency { get; set; }
		public AgeRange AgeRange { get; set; }
		public double? Discount { get; set; }
        [DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }
        public DateTime? DateExpire { get; set; }
    }
}
