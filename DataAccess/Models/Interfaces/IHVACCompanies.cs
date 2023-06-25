namespace DataAccess.Models.Interfaces
{
    internal interface IHVACCompanies
    {
        string? CompanyAddress { get; set; }
        string? CompanyCity { get; set; }
        string? CompanyDescription { get; set; }
        string? CompanyEmailAddress { get; set; }
        int CompanyId { get; set; }
        string? CompanyLogo { get; set; }
        string? CompanyName { get; set; }
        string? CompanyPhoneNumber { get; set; }
        string? CompanyState { get; set; }
        string? CompanyWebsite { get; set; }
        string? CompanyZipCode { get; set; }
        int HVACCompanyId { get; set; }
        int TenantID { get; set; }
    }
}