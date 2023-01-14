using System.ComponentModel;

namespace core.Enums;

/// <summary>
/// ErrorCode
/// </summary>
public enum ErrorCode
{
    /// <summary>
    /// Tenant key unavailable
    /// </summary>
    [Description("Tenant key unavailable")]
    TenantKeyUnavailable = 101,

    /// <summary>
    /// Invalid Tenant
    /// </summary>
    [Description("Invalid Tenant")]
    InvalidTenant = 102,

    /// <summary>
    /// User name cannot be left blank
    /// </summary>
    [Description("User name cannot be left blank")]
    UserNameCannotBeLeftBlank = 201,

    /// <summary>
    /// Password cannot be left blank
    /// </summary>
    [Description("Password cannot be left blank")]
    PasswordCannotBeLeftBlank = 202,

    /// <summary>
    /// User Not Found
    /// </summary>
    [Description("User Not Found")]
    UserNotFound = 203,

    /// <summary>
    /// Incorrect Password
    /// </summary>
    [Description("Incorrect Password")]
    IncorrectPassword = 204
}