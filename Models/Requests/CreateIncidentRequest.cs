using System.ComponentModel.DataAnnotations;
using SecureOpsAPI.Enums;

namespace SecureOpsAPI.Models.Requests;

public class CreateIncidentRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public Severity Severity { get; set; }

    [Required]
    public RecordStatus Status { get; set; }

    public int? RiskId { get; set; }
}