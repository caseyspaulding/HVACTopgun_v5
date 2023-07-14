namespace HVACTopGun.Domain.Features.Tenants
{
    public class TenantSubscriptionModel
    {
        public int TenantId { get; set; }
        public int SubscriptionId { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
