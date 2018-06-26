using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class UserMeasurement
    {
        public UserMeasurement()
        {
        }
        public int UserMeasurementId { get; set; }
        public int UserID { get; set; }
		public MeasurementEntry MeasurementEntry { get; set; }
		public string value { get; set; }
        public List<UserMeasurementHistory> UserMeasurementHistory { get; set; }
    }
}
