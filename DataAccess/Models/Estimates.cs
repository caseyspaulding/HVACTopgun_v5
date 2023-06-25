﻿using DataAccess.Models.Interfaces;

namespace DataAccess.Models
{
    public class Estimates : IEstimates
    {
        public int EstimatesId { get; set; }
        public int TenantId { get; set; }
        public int CustomerId { get; set; }
        public int JobTypeId { get; set; }
        public int HVACCompanyId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public string? ServiceName { get; set; }
        public string? JobTypeName { get; set; }
        public string? CustomerName { get; set; }
        public int Pricing { get; set; }
    }
}
