

namespace HVACTopGun.UI.Models
{
    public class UIUsersModel
    {
        public int UserId { get; set; }
        public int TenantID { get; set; }
        public int AzureAD_ObjectID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string PhoneNumber { get; set; }

    }
}
