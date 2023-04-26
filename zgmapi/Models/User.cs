using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zgmapi.Models;

public class User
{
    [Key]
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "Не правильный номер")]
    public string Phone { get; set; }

    [Required]
    public string Password { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }

}