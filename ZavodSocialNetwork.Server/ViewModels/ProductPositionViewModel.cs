using System.ComponentModel.DataAnnotations;

namespace ZavodSocialNetwork.Server.ViewModels
{
    public class ProductPositionViewModel
    {
        public int id { get; set; }

        public ProductViewModel product { get; set; }
        public string naming { get; set; }
        public string quantity { get; set; }
        public string status { get; set; }
    }
}
