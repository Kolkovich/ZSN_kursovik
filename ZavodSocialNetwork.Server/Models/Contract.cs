using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Contract
{
    [Required]
    public int Id { get; set; }
    
    public int executorId { get; set; }
    public int receiverId { get; set; }
    public int good_package { get; set; }
    public string status { get; set; }
    public int executionconditions { get; set; }
    public int Check { get; set; }
}