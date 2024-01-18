using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Product_package
{
    [Required]
    public int Id { get; set; }
    
    public int executorid { get; set; }
    public int product_position { get; set; }
}