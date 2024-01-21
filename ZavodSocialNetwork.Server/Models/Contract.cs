using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Contract
{
    [Required]
    public int Id { get; set; }
    
    public int? executorId { get; set; }
    public int? receiverId { get; set; }
    public int productId { get; set; }
    public int quntity { get; set; }
    public string status { get; set; } 
    public string exconditions { get; set; }
    public int receiptid { get; set; }
    public string regularity { get; set; }
    public int byId { get; set;} //в случае оффера - id оригинала контракта

    /*
     * Значения Статуса:
        NoN
        ApprovedLikeOffer
        ApprovedByBothSides
        Completed
        Canceled
        Offer
     *
     */
}