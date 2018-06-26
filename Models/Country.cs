using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class Country
    {
        public Country()
        {
        }


        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<State> States { get; set; }
    }
}
