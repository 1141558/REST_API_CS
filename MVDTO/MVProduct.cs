using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.DTO;
using nucleocs.Models;

namespace nucleocs.MVDTO{
    public class MVProduct{
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
        public MVCategory Category { get; set; }
        public ICollection<MVMaterial> Material { get; set; }
        public ICollection<MVAggregation> SubProducts { get; set; }

        public MVProduct(){}

        public MVProduct(int productId, string name, MVCategory category){
            this.ProductId = productId;
            this.Name = name;
            this.Category = category;
        }

        public MVProduct(int productId, string name, double widthMin, double widthMax, double heightMin, double heightMax, 
            double depthMin, double depthMax, double weight, double price, IEnumTypeProd dimensionType, MVCategory category, 
            ICollection<MVMaterial> material, ICollection<MVAggregation> subProducts){

             this.ProductId = productId;
             this.Name = name;
             this.WidthMin = widthMin;
             this.WidthMax = widthMax;
             this.HeightMin = heightMin;
             this.HeightMax = heightMax;
             this.DepthMax = depthMax;
             this.DepthMin = depthMin;
             this.Weight = weight;
             this.Price = price;
             this.DimensionType = dimensionType;
             this.Category = category;
             this.Material = new List<MVMaterial>(material);
             this.SubProducts = new List<MVAggregation>(subProducts);
        }

        public static MVProduct FromFull(Product p){
            var material = new List<MVMaterial>();
            var category = MVCategory.From(p.Category);
            var productSons = new List<MVAggregation>();

            foreach(var mt in p.ProductMaterials){

                material.Add(MVMaterial.From(mt.Material));
            }

            foreach (var agg in p.ProdSon)
            {   
                if(agg.Restrictions.Count != 0)
                    productSons.Add(MVAggregation.From(agg));
            }

            return new MVProduct(p.ProductId, p.Name, p.WidthMin, p.WidthMax, p.HeightMin, p.HeightMax, p.DepthMin, p.DepthMax, 
                p.Weight, p.Price, p.DimensionType, category, material, productSons);
        }

        public static MVProduct FromLitle(Product p){
            var category = MVCategory.From(p.Category);

            return new MVProduct(p.ProductId, p.Name, category);    
        }

    }
}