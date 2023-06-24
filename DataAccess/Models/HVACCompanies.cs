namespace DataAccess.Models
{
    internal class HVACCompanies : IHVACCompanies
    {
        public int HVACCompanyId { get; set; }
        public int TenantID { get; set; } // foreign key referencing tenants table
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyCity { get; set; }
        public string? CompanyState { get; set; }
        public string? CompanyZipCode { get; set; }
        public string? CompanyPhoneNumber { get; set; }
        public string? CompanyEmailAddress { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyLogo { get; set; }


    }
}
