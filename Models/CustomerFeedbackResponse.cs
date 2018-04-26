using System;
using System.ComponentModel;

namespace jannieCouture.Models
{
    public class CustomerFeedbackResponse
    {
        public CustomerFeedbackResponse()
        {
        }

        public int CustomerFeedbackResponseId { get; set; }
        public string Response { get; set; }
        public int UserId { get; set;  }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }
        public CustomerFeedbackResponse ParentResponse { get; set; }
	}
}
