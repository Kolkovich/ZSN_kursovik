using System.ComponentModel.DataAnnotations;

namespace ZavodSocialNetwork.Server.Models;

public class Receipt
{
    [Required]
    public int Id { get; set; }
    
    public string total_payment { get; set; }
    public string expenses { get; set; }
    public string our_share { get; set; }
}