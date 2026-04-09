using System.ComponentModel.DataAnnotations;
using SecureOpsAPI.Enums;

namespace SecureOpsAPI.Models;

public class Risk
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public Severity Severity { get; set; }

    [Required]
    public string Owner { get; set; } = string.Empty;

    [Required]
    public Status Status { get; set; }
}