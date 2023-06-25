namespace DataAccess.Models.Interfaces
{
    public interface IAvailableAppointmentModel
    {
        DateTime CreatedAt { get; set; }
        DateTime EndDate { get; set; }
        DateTime EndTime { get; set; }
        int Id { get; set; }
        bool Reserved { get; set; }
        DateTime StartDate { get; set; }
        DateTime StartTime { get; set; }
        int TenantId { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}