using System.ComponentModel.DataAnnotations;

namespace ZavodSocialNetwork.Server.Models;

public class Check
{
    [Required]
    public int Id { get; set; }
    
    public string Total_Payment { get; set; }
    public string Expenses { get; set; }
    public string Our_Share { get; set; }
}