using System;
namespace jannieCouture.Models
{
    public class CustomerFeedback
    {
        public CustomerFeedback()
        {
        }

        public int CustomerFeedbackId { get; set; }
        public int UserId { get; set; }
        public string Feedback { get; set; }
        public Order Order { get; set; }
        public CustomerFeedback ParentFeedback { get; set; } 
        public FeedbackStatus FeedbackStatus { get; set; }
    }
}
