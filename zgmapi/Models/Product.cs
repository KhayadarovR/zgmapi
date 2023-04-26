using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    [Required]
    public double DefaultPrice { get; set; }
}