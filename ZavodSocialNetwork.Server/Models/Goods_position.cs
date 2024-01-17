using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Goods_position
{
    [Required]
    public int Id { get; set; }
    
    public int Idgoods { get; set; }
    public string naming { get; set; }
    public string quantity { get; set; }
    public string status { get; set; }
}