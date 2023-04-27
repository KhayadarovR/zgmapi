using System.ComponentModel.DataAnnotations;
using System.Data;

namespace zgmapi.Models;

public class Order
{
    [Key]
    public long Id { get; set; } 
    
    [Required]
    public long UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public int ProductItemId { get; set; }
    public ProductItem ProductItem { get; set; }
    
    [Required]
    public short Count { get; set; }

    [Required] public DateTime Time { get; set; }
    
    [Required]
    public float TotalPrice { get; set; } 
}