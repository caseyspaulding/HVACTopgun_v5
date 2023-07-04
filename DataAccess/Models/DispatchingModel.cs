

namespace DataAccess.Models
{
    public class DispatchingModel
    {
        public int DispatchId { get; set; }
        public int TenantID { get; set; }

        public int JobTypeId { get; set; }
        public int CustomerId { get; set; }
        public int AppointmentId { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }

    }
}
