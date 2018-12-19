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
        public ICollection<MVMaterial> MvMaterial { get; set; }
        public ICollection<MVAggregation> MVProductsSon { get; set; }

        public MVProduct(){}

        public MVProduct(int productId, string name, MVCategory category){
            this.ProductId = productId;
            this.Name = name;
            this.Category = category;
        }

        public MVProduct(int productId, string name, double widthMin, double widthMax, double heightMin, double heightMax, 
            double depthMin, double depthMax, double weight, double price, IEnumTypeProd dimensionType, MVCategory categoryMV, 
            ICollection<MVMaterial> materialMV, ICollection<MVAggregation> productsSonMV){

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
             this.Category = categoryMV;
             this.MvMaterial = new List<MVMaterial>(materialMV);
             this.MVProductsSon = new List<MVAggregation>(productsSonMV);
        }

        public static MVProduct FromFull(ProductDTO p){
            var material = new List<MVMaterial>();
            var category = MVCategory.From(p.CategoryD);
            var productsSon = new List<MVAggregation>();

            foreach(var mt in p.ProductMaterials){

                material.Add(MVMaterial.From(mt.MaterialD));
            }

            foreach (var agg in p.ProductsSon)
            {   
                if(agg.RestrictionsDTO.Count != 0)
                    productsSon.Add(MVAggregation.From(agg));
            }

            return new MVProduct(p.ProductId, p.Name, p.WidthMin, p.WidthMax, p.HeightMin, p.HeightMax, p.DepthMin, p.DepthMax, 
                p.Weight, p.Price, p.DimensionType, category, material, productsSon);
        }

        public static MVProduct FromLitle(ProductDTO p){
            var category = MVCategory.From(p.CategoryD);

            return new MVProduct(p.ProductId, p.Name, category);    
        }

    }
}