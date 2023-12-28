using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class User
{
    [Required]
    public int Id { get; set; }
    
    public string Role { get; set; }
    public string Phone { get; set; }
    public string Organization { get; set; }
}