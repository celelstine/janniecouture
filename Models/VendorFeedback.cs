using System;
namespace jannieCouture.Models
{
    public class VendorFeedback
    {
        public VendorFeedback()
        {
        }

         public int VendorFeedbackId { get; set; }
        public Vendor  Vendor  { get; set; }
        public string Feedback { get; set; }
        public Supply  Supply { get; set; }
        public VendorFeedback ParentFeedback { get; set; } 
        public FeedbackStatus FeedbackStatus { get; set; }
    }
}
