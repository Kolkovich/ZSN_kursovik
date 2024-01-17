using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Goods_package
{
    [Required]
    public int Id { get; set; }
    
    public int executorid { get; set; }
    public int goods_position { get; set; }
}