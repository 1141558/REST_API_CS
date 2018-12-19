using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.DTO;

namespace nucleocs.Models{
    public class ProductMaterialDTO
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ProductDTO ProductD { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public MaterialDTO MaterialD { get; set; }

        public ProductMaterialDTO(){}
    }
}
