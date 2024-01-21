using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class User
{
    [Required]
    public int Id { get; set; }
    
    public string Role { get; set; } //Всего два вида: User и Admin
    public string Phone { get; set; }
    public string Organisation { get; set; }
    public string Password { get; set; }
}