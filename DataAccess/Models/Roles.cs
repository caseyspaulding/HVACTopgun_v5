namespace DataAccess.Models
{
    public class Roles : IRoles
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public string? RoleType { get; set; }
    }

}
