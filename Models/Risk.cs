using System.ComponentModel.DataAnnotations;
using SecureOpsAPI.Enums;

namespace SecureOpsAPI.Models;

public class Risk
{
    public int Id { get; set; }

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

    public List<Incident> Incidents { get; set; } = new();
}