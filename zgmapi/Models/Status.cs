using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Status
{
    [Key]
    public int Id { get; set; }
    [Required] public string Current { get; set; }
    
    public virtual ICollection<ProductItem> ProductItems { get; }
}