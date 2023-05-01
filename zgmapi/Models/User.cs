using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace zgmapi.Models;

public class User
{
    [Key]
    [JsonIgnore]
    public long Id { get; set; }
    [StringLength(255)]
    public string? Name { get; set; }
    [StringLength(255)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Вы обязаны заполнить поле")]
    [StringLength(20, ErrorMessage = "Не правильный номер")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Вы обязаны заполнить поле")]
    [StringLength(255)]
    public string Password { get; set; } = null!;
    public int RoleId { get; set; }
    [JsonIgnore]
    public virtual Role? Role { get; set; }

}