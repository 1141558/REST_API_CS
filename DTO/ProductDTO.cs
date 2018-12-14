using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.DTO
{
    public class ProductDTO{
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double WidthMin { get; set; }//largura minima
        public double WidthMax { get; set; }//largura maxima
        public double HeightMin { get; set; }//altura minima
        public double HeightMax { get; set; }//altura maxima
        public double DepthMin { get; set; }//profundidade minima
        public double DepthMax { get; set; }//profundidade maxima
        public double Weight { get; set; }
        public double Price { get; set; }
        public IEnumTypeProd DimensionType { get; set; }
        public Category Category { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<AggregationDTO> SubProducts { get; set; }
        public List<int> RestrictionsIds { get; set; }
        public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }

        public ProductDTO(){}
    }
}