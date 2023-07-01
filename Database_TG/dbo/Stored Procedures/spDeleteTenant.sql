CREATE PROCEDURE [dbo].[spDeleteTenant]
	@TenantID int
AS
BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Set the Deleted flag for the tenant in the Tenants table
        UPDATE Tenants
    SET Deleted = 1,
        DateDeleted = GETDATE()
    WHERE TenantID = @TenantId;

        -- Update the Deleted flag in other tables that reference the tenant
        UPDATE Appointments
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE [Availability]
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE ChatbotConversations
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE AvailableAppointment
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE CustomerBilling
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE CustomerHistory
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Customers
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE HVACCompanies
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Inventory
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Invoices
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Payments
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE PriceBook
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Subscriptions
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE [Services]
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Subscriptions
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Technicians
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        UPDATE Users
        SET Deleted = 1,
        DateDeleted = GETDATE()
        WHERE TenantID = @TenantId;

        
        
        -- Add similar updates for other tables that reference the tenant
        
        -- Commit the transaction
        COMMIT;
    END TRY
    BEGIN CATCH
        -- Handle any exceptions and rollback the transaction if needed
        IF @@TRANCOUNT > 0
            ROLLBACK;
            
        -- Optionally, re-throw the exception to the calling code
        -- THROW;
    END CATCH;
END;