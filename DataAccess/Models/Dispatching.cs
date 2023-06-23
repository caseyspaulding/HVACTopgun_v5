namespace DataAccess.Models
{
    public class Dispatching
    {
        public int DispatchId { get; set; }
        public int TenantId { get; set; }

        public int JobTypeId { get; set; }
        public int CustomerId { get; set; }
        public int AppointmentId { get; set; }

    }
}
