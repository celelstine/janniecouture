using System;
using System.ComponentModel;

namespace jannieCouture.Models
{
    public class VendorFeedbackResponse
    {
        public VendorFeedbackResponse()
        {
        }

        public int VendorFeedbackResponseId { get; set; }
        public string Response { get; set; }
        public Vendor Vendor { get; set;  }
        [DefaultValue(typeof(DateTime), "")]
        public DateTime DateCreated { get; set; }
        public VendorFeedbackResponse ParentResponse { get; set; }
    }
}
