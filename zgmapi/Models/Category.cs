using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}