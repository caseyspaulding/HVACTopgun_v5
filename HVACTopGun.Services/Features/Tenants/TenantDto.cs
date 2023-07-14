using HVACTopGun.Domain.Features.Payments;
using System.Data.SqlTypes;

namespace HVACTopGun.Application.Features.Tenants
{
    public class TenantDto
    {

        public int TenantID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string TimeZone { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime DateDeleted { get; set; }

        public string? SubscriptionType { get; set; }

        public PaymentStatusDto PaymentStatus { get; set; }

        private DateTime? trialExpirationDate;

        public DateTime? TrialExpirationDate
        {
            get { return trialExpirationDate; }
            set { trialExpirationDate = ValidateTrialExpirationDate(value); }
        }

        private DateTime? ValidateTrialExpirationDate(DateTime? value)
        {
            if (value.HasValue && (value.Value < SqlDateTime.MinValue.Value || value.Value > SqlDateTime.MaxValue.Value))
            {
                return null; // Set it to null or handle it accordingly
            }

            return value;
        }

    }
}