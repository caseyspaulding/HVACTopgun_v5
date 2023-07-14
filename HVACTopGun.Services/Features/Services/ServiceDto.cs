namespace HVACTopGun.Domain.Features.Services
{
    public class ServiceDto
    {
        public int ServiceId { get; set; }
        public int TenantID { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceImage { get; set; }
        public string? ServiceVideo { get; set; }
        public string? ServiceIcon { get; set; }
        public string? ServiceCategory { get; set; }
        public string? ServiceSubCategory { get; set; }
        public string? ServiceType { get; set; }
        public string? ServicePrice { get; set; }
        public string? ServicePriceType { get; set; }
        public string? ServicePriceDescription { get; set; }
        public string? ServicePriceIcon { get; set; }
        public string? ServicePriceImage { get; set; }
        public string? ServiceDuration { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }


    }
}
