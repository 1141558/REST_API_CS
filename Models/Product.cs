using System.Collections.Generic;
using nucleocs.Models.Strategy;

namespace nucleocs.Models
{
    public class Product{
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double WidthMin { get; set; }//largura minima
        public double WidthMax { get; set; }//largura maxima
        public double HeightMin { get; set; }//altura minima
        public double HeightMax { get; set; }//altura maxima
        public double DepthMax { get; set; }//profundidade maxima
        public double DepthMin { get; set; }//profundidade minima
        public double Price { get; set; }
        public double Weight { get; set; }//peso
        public IEnumTypeProd DimensionType { get; set; }
        public Category Category { get; set; }//Product tem 1 category
        public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }
        public virtual ICollection<Aggregation> ProdSon { get; set; }
        public Product (){
            this.ProductMaterials = new List<ProductMaterial>();
            this.ProdSon = new List<Aggregation>();
        } 
       
    }
}