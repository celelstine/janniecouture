using System;
namespace jannieCouture.Models
{
    public class MeasurementCategoryEntry
    {
        public MeasurementCategoryEntry()
        {
        }
        public int MeasurementCategoryEntryId { get; set; }
        public MeasurementCategory MeasurementCategory { get; set; }
        public MeasurementEntry MeasurementEntry { get; set; }
    }
}
