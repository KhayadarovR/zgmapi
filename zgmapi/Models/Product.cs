using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    [Required] public string Title { get; set; } = null!;
    [Required]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    [Required]
    public double DefaultPrice { get; set; }
}