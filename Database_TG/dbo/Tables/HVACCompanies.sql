CREATE TABLE [dbo].[HVACCompanies]
(
    [HVACCompanyId] INT NOT NULL PRIMARY KEY IDENTITY,
     [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [CompanyId] INT NOT NULL,
    [CompanyName] NVARCHAR(100) NULL,
    [CompanyAddress] NVARCHAR(100) NULL,
    [CompanyCity] NVARCHAR(100) NULL,
    [CompanyState] NVARCHAR(50) NULL,
    [CompanyZipCode] NVARCHAR(20) NULL,
    [CompanyPhoneNumber] NVARCHAR(20) NULL,
    [CompanyEmailAddress] NVARCHAR(100) NULL,
    [CompanyWebsite] NVARCHAR(100) NULL,
    [CompanyDescription] NVARCHAR(MAX) NULL,
    [CompanyLogo] NVARCHAR(100) NULL,
    CONSTRAINT FK_HVACCompanies_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)
