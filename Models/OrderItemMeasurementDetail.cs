using System;
namespace jannieCouture.Models
{
    public class OrderItemMeasurementDetail
    {
        public OrderItemMeasurementDetail()
        {
        }

        public int OrderItemMeasurementDetailId { get; set; }
        public OrderItemMeasurement OrderItemMeasurement { get; set; } 
        public MeasurementEntry MeasurementEntry { get; set; }
        public string value { get; set; }
    }
}
