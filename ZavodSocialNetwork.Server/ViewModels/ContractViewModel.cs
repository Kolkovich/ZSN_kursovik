using System.ComponentModel.DataAnnotations;
using ZavodSocialNetwork.Server.Models;

namespace ZavodSocialNetwork.Server.ViewModels
{
    public class ContractViewModel
    {
        public int id { get; set; }
        public string? executor { get; set; }
        public string? receiver { get; set; }
        //массив класса с массивом класса со ссылкой на класс - то, что просто из бд нельзя взять - неактуальная запись
        //здесь были пакеты, но мы это упростили до ссылки на продукт и поля "кол-во"
        //теперь нет типизации продуктов :(
        public Product product { get; set; }
        public int quntity { get; set; }
        public string status { get; set; }
        public string exconditions { get; set; }
        public Receipt receipt { get; set; }
        public string regularity { get; set; }
        public int byId { get; set; }
    }
}
