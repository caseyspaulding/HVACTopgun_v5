namespace DataAccess.Models.Interfaces
{
    public interface IServices
    {
        string? ServiceCategory { get; set; }
        string? ServiceDescription { get; set; }
        string? ServiceDuration { get; set; }
        string? ServiceIcon { get; set; }
        int ServiceID { get; set; }
        string? ServiceImage { get; set; }
        string? ServiceName { get; set; }
        string? ServicePrice { get; set; }
        string? ServicePriceDescription { get; set; }
        string? ServicePriceIcon { get; set; }
        string? ServicePriceImage { get; set; }
        string? ServicePriceType { get; set; }
        string? ServiceSubCategory { get; set; }
        string? ServiceType { get; set; }
        string? ServiceVideo { get; set; }
        int TenantID { get; set; }
    }
}