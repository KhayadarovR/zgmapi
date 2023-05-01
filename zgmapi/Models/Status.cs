using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Status
{
    [Key]
    public int Id { get; set; }
    [StringLength(255)]
    [Required] public string Current { get; set; } = null!;
    
    public virtual ICollection<ProductItem> ProductItems { get; }
}