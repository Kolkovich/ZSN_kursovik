using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Regularity
{
    [Required]
    public int Id { get; set; }
    
    public string How_many { get; set; }
    public string How_often { get; set; }
}