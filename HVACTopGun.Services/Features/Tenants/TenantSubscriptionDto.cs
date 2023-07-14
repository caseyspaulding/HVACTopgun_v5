namespace HVACTopGun.Application.Features.Tenants
{
    public class TenantSubscriptionDto
    {
        public int TenantId { get; set; }
        public int SubscriptionId { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
