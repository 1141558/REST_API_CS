using System.ComponentModel.DataAnnotations.Schema;

namespace nucleocs.Models{
    public class ProductMaterial
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public ProductMaterial(){}
    }
}
