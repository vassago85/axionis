namespace AxionisPos.Api.Options;

public class PlatformOptions
{
    public const string SectionName = "Platform";

    public string Name { get; set; } = "Axionis POS";
    public string Tagline { get; set; } = "Built for mobility. Designed for real-world operations.";
    public string DefaultPrimaryColor { get; set; } = "#0f172a";
    public string DefaultAccentColor { get; set; } = "#06b6d4";
    public string DefaultLogoPath { get; set; } = "";
    public string DefaultFaviconPath { get; set; } = "";
}
