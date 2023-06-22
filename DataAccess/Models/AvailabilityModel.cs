namespace DataAccess.Models
{
    public class AvailabilityModel
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}