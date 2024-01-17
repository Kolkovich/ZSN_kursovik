using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Conditions
{
    [Required]
    public int Id { get; set; }
    
    public int regularity { get; set; }
    public string shipping{ get; set; }
}