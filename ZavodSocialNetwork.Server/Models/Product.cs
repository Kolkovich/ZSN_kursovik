using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Product
{
    [Required]
    public int Id { get; set; }
    
    public string description { get; set; }
}