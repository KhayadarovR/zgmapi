using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Stock
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    [Required] public string Title { get; set; } = null!;

    public string? Descriptions { get; set; }
    [StringLength(255)]
    public string? Address { get; set; }
}