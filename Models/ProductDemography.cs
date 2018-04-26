using System;
namespace jannieCouture.Models
{
    public class ProductDemography
    {
        public ProductDemography()
        {
        }
        public int ProductDemographyId { get; set; }
        public Product Product { get; set; }
        public Demography Demography { get; set; }
        public string value { get; set; }
    }
}
