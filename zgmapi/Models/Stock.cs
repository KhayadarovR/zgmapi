using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Stock
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    public string? Descriptions { get; set; }
    
    public string? Address { get; set; }
}