namespace SecureOpsUI.Models;

public class Incident
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int? RiskId { get; set; }
}