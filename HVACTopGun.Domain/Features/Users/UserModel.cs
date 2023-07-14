namespace HVACTopGun.Domain.Features.Users
{
    public class UserModel
    {

        public int UserId { get; set; }
        public int TenantID { get; set; }
        public string? AzureAD_ObjectID { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime? DateDeleted { get; set; }






    }

}
