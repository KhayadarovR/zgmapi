using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(255)]
    [Required] public string Title { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; }
}