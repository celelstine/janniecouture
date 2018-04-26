using System;
namespace jannieCouture.Models
{
    public class Material
    {
        public Material()
        {
        }

        public int MaterialId { get; set; }
        public MaterialCategory MaterialCategory  { get; set; }
        public double QuantityinStock { get; set; }
        public SKU SKU { get; set; }
        public double WarningQuantity { get; set; }
    }
}
