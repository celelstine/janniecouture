using System;
using System.Collections.Generic;
namespace jannieCouture.Models
{
    public class MaterialCategory
    {
        public MaterialCategory()
        {
        }

		public int MaterialCategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public List<Material> Materials { get; set; }
    }
}
