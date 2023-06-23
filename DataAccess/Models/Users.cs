namespace DataAccess.Models
{
    public class Users
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? EmailAddress { get; set; }
        public int RoleId { get; set; }
        public string? Password { get; set; }

    }

}
