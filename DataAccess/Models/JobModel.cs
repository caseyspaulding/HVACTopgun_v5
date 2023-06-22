using DataAccess.Enums;

namespace DataAccess.Models
{
    public class JobModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? TechnicianName { get; set; }
        public string? CustomerName { get; set; }
        public string? Location { get; set; }
        public JobStatus Status { get; set; }
    }
}