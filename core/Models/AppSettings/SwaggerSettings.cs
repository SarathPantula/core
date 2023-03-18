namespace core.Models.AppSettings;

/// <summary>
/// Swagger Configuration
/// </summary>
public class SwaggerSettings
{
    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// Version
    /// </summary>
    public string Version { get; set; } = null!;
    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; } = null!;
    /// <summary>
    /// TermsOfService
    /// </summary>
    public string TermsOfService { get; set; } = null!;
    /// <summary>
    /// Contact
    /// </summary>
    public SwaggerContact Contact { get; set; } = null!;
    /// <summary>
    /// License
    /// </summary>
    public SwaggerLicense License { get; set; } = null!;

    /// <summary>
    /// Swagger Contact
    /// </summary>
    public class SwaggerContact
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = null!;
    }

    /// <summary>
    /// 
    /// </summary>
    public class SwaggerLicense
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = null!;
    }
}