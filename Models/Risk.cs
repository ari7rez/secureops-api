using System.ComponentModel.DataAnnotations;

namespace SecureOpsAPI.Models;

public class Risk
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Severity { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Owner { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = string.Empty;
}