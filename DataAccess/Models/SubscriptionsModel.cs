

namespace DataAccess.Models
{
    public class SubscriptionsModel
    {
        public int SubscriptionId { get; set; }


        public string? Price { get; set; }
        public string? Features { get; set; }
        public string? Status { get; set; }


        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }



    }
}
