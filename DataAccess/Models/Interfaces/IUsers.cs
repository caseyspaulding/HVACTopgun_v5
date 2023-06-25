namespace DataAccess.Models.Interfaces
{
    public interface IUsers
    {
        string? EmailAddress { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? Password { get; set; }
        int RoleId { get; set; }
        int UserId { get; set; }
    }
}