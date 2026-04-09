namespace SecureOpsUI.Models;

public class Risk
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Severity { get; set; } = "Low";
    public string Owner { get; set; } = string.Empty;
    public string Status { get; set; } = "Open";
}