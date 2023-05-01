using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class Role
{
    [Key]

    public int Id { get; set; }
    [StringLength(255)]
    [Required] public string Name { get; set; } = null!;
    
    public virtual ICollection<User> Users { get; }
}