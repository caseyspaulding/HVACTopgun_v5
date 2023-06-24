namespace DataAccess.Models
{
    public interface IDispatching
    {
        int AppointmentId { get; set; }
        int CustomerId { get; set; }
        int DispatchId { get; set; }
        int JobTypeId { get; set; }
        int TenantId { get; set; }
    }
}