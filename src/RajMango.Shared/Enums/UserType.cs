namespace RajMango.Shared.Enums
{
    public enum UserType
    {
        None = 0,            // Undefined or not assigned

        SysAdmin = 1,        // System-level administrator with full backend access
        Admin = 2,           // Application-level administrator for managing content/users

        General = 3,         // Standard user (customer or basic internal user)

        Manager = 4,         // Operational or team manager with elevated access
        Staff = 5,           // Internal employee or staff with workflow/task permissions
        
        Guest = 6,           // Temporary or restricted-access user

        Auditor = 7,         // Read-only role for compliance/review purposes
        Support = 8,         // Customer support agent with limited edit access

        Vendor = 9,          // External service provider with scoped permissions
        DeliveryAgent = 10,  // For logistics/delivery role, if applicable

        ReadOnly = 11        // System-level read-only access
    }
}
