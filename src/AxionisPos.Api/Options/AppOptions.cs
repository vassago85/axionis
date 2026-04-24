namespace AxionisPos.Api.Options;

public class AppOptions
{
    public const string SectionName = "App";
    public string PublicBaseUrl { get; set; } = "http://localhost:5173";
    public string PdfStoragePath { get; set; } = "storage/pdfs";
    public string BrandingStoragePath { get; set; } = "storage/branding";
    public bool HideCostForSalesRole { get; set; } = true;

    /// <summary>Shown on customer receipts (email, PDF, public invoice page).</summary>
    public string CompanyDisplayName { get; set; } = "";

    public string CompanyPhone { get; set; } = "";
    public string CompanyEmail { get; set; } = "";

    /// <summary>Single line or short block for the shop address.</summary>
    public string CompanyAddress { get; set; } = "";

    public string CompanyVatNumber { get; set; } = "";

    public string CompanyWebsite { get; set; } = "";

    /// <summary>Short link text for <see cref="CompanyWebsite"/> (e.g. yourshop.com). If empty, derived from the URL.</summary>
    public string CompanyWebsiteLabel { get; set; } = "";
}
