using System;
namespace jannieCouture.Models
{
    public class Vendor
    {
        public Vendor()
        {
        }

        public int VendorId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DeliveryAddress Address  { get; set; }
        public Rating Rating { get; set; }
    }
}
