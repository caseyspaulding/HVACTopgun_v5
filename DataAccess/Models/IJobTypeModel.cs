namespace DataAccess.Models
{
    public interface IJobTypeModel
    {
        string? Description { get; set; }
        int Id { get; set; }
        string? Name { get; set; }
    }
}