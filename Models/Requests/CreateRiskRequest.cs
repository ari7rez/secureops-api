using System.ComponentModel.DataAnnotations;
using SecureOpsAPI.Enums;

namespace SecureOpsAPI.Models.Requests;

public class CreateRiskRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public Severity Severity { get; set; }

    [Required]
    [StringLength(50)]
    public string Owner { get; set; } = string.Empty;

    [Required]
    public RecordStatus Status { get; set; }
}