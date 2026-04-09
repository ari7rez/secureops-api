namespace SecureOpsUI.Models;

public class Incident
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Severity { get; set; } = "Low";
    public string Status { get; set; } = "Open";
    public int? RiskId { get; set; }
}