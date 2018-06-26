using System;
using System.ComponentModel;
namespace jannieCouture.Models
{
    public class UserMeasurementHistory
    {
        public UserMeasurementHistory()
        {
        }
        public int UserMeasurementHistoryId { get; set; }
        public int UserID { get; set; }
        public MeasurementEntry MeasurementEntry { get; set; }
        public string value { get; set; }
		[DefaultValue(typeof(DateTime), "")]
        public DateTime DateCreated { get; set; }
    }
}
