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
        public CategoryDTO CategoryD { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<MaterialDTO> MaterialD { get; set; }
        public ICollection<AggregationDTO> SubProducts { get; set; }
        public List<int> RestrictionsIds { get; set; }
        public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }

        public ProductDTO(){}
        public ProductDTO(int productId, string name, CategoryDTO category){
            this.ProductId = productId;
            this.Name = name;
            this.CategoryD = category;
        }

        public ProductDTO(int productId, string name, double widthMin, double widthMax, double heightMin, double heightMax, 
            double depthMin, double depthMax, double weight, double price, IEnumTypeProd dimensionType, CategoryDTO categoryDTO, 
            ICollection<MaterialDTO> materialDTO, ICollection<AggregationDTO> subProductsDTO){

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
             this.CategoryD = categoryDTO;
             this.MaterialD = new List<MaterialDTO>(materialDTO);
             this.SubProducts = new List<AggregationDTO>(subProductsDTO);
        }

        public static ProductDTO FromFull(Product p){
            var material = new List<MaterialDTO>();
            var category = CategoryDTO.From(p.Category);
            var productSons = new List<AggregationDTO>();

            foreach(var mt in p.ProductMaterials){

                material.Add(MaterialDTO.From(mt.Material));
            }

            foreach (var agg in p.ProdSon)
            {   
                if(agg.Restrictions.Count != 0)
                    productSons.Add(AggregationDTO.From(agg));
            }

            return new ProductDTO(p.ProductId, p.Name, p.WidthMin, p.WidthMax, p.HeightMin, p.HeightMax, p.DepthMin, p.DepthMax, 
                p.Weight, p.Price, p.DimensionType, category, material, productSons);
        }

        public static ProductDTO FromLitle(Product p){
            var category = CategoryDTO.From(p.Category);

            return new ProductDTO(p.ProductId, p.Name, category);    
        }

    }
}