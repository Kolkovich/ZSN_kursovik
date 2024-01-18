using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Product_position
{
    [Required]
    public int Id { get; set; }
    
    public int idproduct { get; set; }
    public string naming { get; set; }
    public string quantity { get; set; }
    public string status { get; set; }
}