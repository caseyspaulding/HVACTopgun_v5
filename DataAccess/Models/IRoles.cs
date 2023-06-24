namespace DataAccess.Models
{
    public interface IRoles
    {
        string? RoleDescription { get; set; }
        int RoleId { get; set; }
        string? RoleName { get; set; }
        string? RoleType { get; set; }
    }
}