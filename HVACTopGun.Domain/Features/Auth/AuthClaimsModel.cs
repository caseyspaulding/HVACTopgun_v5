namespace HVACTopGun.Domain.Features.Auth
{
    public class AuthClaimsModel
    {
        public string? IdentityProvider { get; set; }
        public string? CompanyName { get; set; }
        public string? ObjectId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }


    }
}
