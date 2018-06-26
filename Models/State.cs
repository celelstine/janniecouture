using System;
namespace jannieCouture.Models
{
    public class State
    {
        public State()
        {
        }


        public int StateId { get; set; }
        public Country Country { get; set;  }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
