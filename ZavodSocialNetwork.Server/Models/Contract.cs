﻿using System.ComponentModel.DataAnnotations;
namespace ZavodSocialNetwork.Server.Models;

public class Contract
{
    [Required]
    public int Id { get; set; }
    
    public int executorId { get; set; }
    public int receiverId { get; set; }
    public int product_package { get; set; }
    public string status { get; set; }
    public string exconditions { get; set; }
    public int receiptid { get; set; }
    public string regularity { get; set; }
}