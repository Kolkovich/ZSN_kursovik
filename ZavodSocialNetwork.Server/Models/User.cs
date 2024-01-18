using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class User
{
    [Required]
    public int Id { get; set; }
    
    public string role { get; set; }
    public string phone { get; set; }
    public string organisation { get; set; }
    public string password { get; set; }
}