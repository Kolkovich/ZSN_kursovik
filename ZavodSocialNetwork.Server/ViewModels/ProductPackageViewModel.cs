using System.ComponentModel.DataAnnotations;

namespace ZavodSocialNetwork.Server.ViewModels
{
    public class ProductPackageViewModel
    {
        public int id { get; set; }

        public string executor { get; set; }
        public List<ProductPositionViewModel> positions { get; set; }
    }
}
