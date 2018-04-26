using System;
using System.ComponentModel;
using System.Collections.Generic;
namespace jannieCouture.Models
{
    public class OrderItemMeasurement
    {
        public OrderItemMeasurement()
        {
        }

        public int OrderItemMeasurementId { get; set; }
        public OrderItem OrderItem { get; set; }
        public Boolean CanBeModified { get; set; }
        public List<OrderItemMeasurementDetail> OrderItemMeasurementDetails { get; set; }
    }
}
