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
    public string? Name { get; set; }
    public string? LastName { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "Не правильный номер")]
    public string Phone { get; set; }

    [Required]
    public string Password { get; set; }
    [JsonIgnore]
    public int RoleId { get; set; }
    [JsonIgnore]
    public virtual Role? Role { get; set; }

}