using System;
namespace jannieCouture.Models
{
    public class MeasurementEntry
    {
        public MeasurementEntry()
        {
        }
		public int MeasurementEntryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public string MeasurementUnit { get; set; }
    }
}
