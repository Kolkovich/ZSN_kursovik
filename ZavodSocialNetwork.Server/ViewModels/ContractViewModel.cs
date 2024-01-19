using System.ComponentModel.DataAnnotations;
using ZavodSocialNetwork.Server.Models;

namespace ZavodSocialNetwork.Server.ViewModels
{
    public class ContractViewModel
    {
        public int id { get; set; }
        public string? executor { get; set; }
        public string? receiver { get; set; }
        //массив класса с массивом класса со ссылкой на класс - то, что просто из бд нельзя взять
        public List<ProductPackageViewModel> packages { get; set; }
        public string status { get; set; }
        public string exconditions { get; set; }
        public Receipt receipt { get; set; }
        public string regularity { get; set; }
    }
}
