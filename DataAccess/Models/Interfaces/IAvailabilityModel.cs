namespace DataAccess.Models.Interfaces
{
    public interface IAvailabilityModel
    {
        DayOfWeek DayOfWeek { get; set; }
        TimeSpan EndTime { get; set; }
        int Id { get; set; }
        bool IsAvailable { get; set; }
        TimeSpan StartTime { get; set; }
        int TenantId { get; set; }
    }
}