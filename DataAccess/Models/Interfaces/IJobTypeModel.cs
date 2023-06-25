namespace DataAccess.Models.Interfaces
{
    public interface IJobTypeModel
    {
        string? Description { get; set; }
        int Id { get; set; }
        string? Name { get; set; }
    }
}