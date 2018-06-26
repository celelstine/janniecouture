using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class MeasurementCategory
    {
        public MeasurementCategory()
        {
        }
		public int MeasurementCategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public List<MeasurementCategoryEntry> MeasurementCategoryEntries { get; set; }
    }
}
