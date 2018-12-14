using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using nucleocs.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using nucleocs.DTO;
using Microsoft.EntityFrameworkCore;
using nucleocs.Data;
using nucleocs.MVDTO;
using nucleocs.Services;
using nucleocs.Models.Strategy;
using nucleocs.Services.Interfaces;
using nucleocs.Data.Repositories.Interfaces;
using nucleocs.Data.Repositories;

namespace nucleocs.Services{
    public class ProductService : IProductService{
        
        private readonly IProductRepository _repositoryProduct;
        private readonly ICategoryRepository _repositoryCategory;
        private readonly IMaterialRepository _repositoryMaterial;

        public ProductService(IProductRepository repositoryProduct, ICategoryRepository repositoryCategory, IMaterialRepository repositoryMaterial){
            _repositoryProduct = repositoryProduct;
            _repositoryCategory = repositoryCategory;
            _repositoryMaterial = repositoryMaterial;

        }

        public List<MVProduct> GetAllProducts(){
            return _repositoryProduct.GetAll();
        }

        public Product GetProductByID(int id){

            return _repositoryProduct.GetById(id);
        }

        public List<MVProduct> GetProductByName(string name){

            return  _repositoryProduct.GetByName(name);
        }

        public Product GetProductByNameSingle(string name){

            return  _repositoryProduct.GetByNameSingle(name);
        }

        public Product GetProductParts(ProductDTO prod){

            return _repositoryProduct.GetById(prod.ProductId);
        }

        public Product CreateLitleProduct(ProductDTO product){
            var prod = new Product();
            var item = _repositoryProduct.GetByNameSingle(product.Name); //Verifica se já existe algum produto com o nome passado por parametro

            if(item == null){ //se não existir irá criar um produto novo
                if(product.Name.Length.Equals(null)){
                    return null;
                }else{
                    prod.Name = product.Name;
                }
                
                //valida se o id da categoria passado por parametro existe
                var category = _repositoryCategory.GetById(product.Category.CategoryId);
                if(category != null){
                    prod.Category = category;
                }else
                    return null; //mensagem erro de id categoria não existe 

                _repositoryProduct.Create(prod);
            }else{
                return null;
            }         
            return prod;
        }

        public Product CreateFullProduct(ProductDTO product){
            var prod = new Product();
            var item = _repositoryProduct.GetByNameSingle(product.Name); //Verifica se já existe algum produto com o nome passado por parametro
            
            //se não existir irá criar um produto novo
            if(item == null){

                //Verificar de o nome é string vazia
                if(product.Name.Length.Equals(null)){
                    return null;
                }else{
                    prod.Name = product.Name;
                }
                prod.WidthMin = product.WidthMin;
                prod.WidthMax = product.WidthMax;
                prod.HeightMin = product.HeightMin;
                prod.HeightMax = product.HeightMax;
                prod.DepthMin = product.DepthMin;
                prod.DepthMax = product.DepthMax;
                prod.Price = product.Price;
                prod.Weight = product.Weight;

                if((product.HeightMin == 0.00) && (product.WidthMin == 0.00) && (product.Weight == 0.00)){
                    prod.DimensionType = IEnumTypeProd.Discreet;
                }else{
                    prod.DimensionType = IEnumTypeProd.Continued;
                }
                
                //valida se o id da categoria passado por parametro existe
                var category = _repositoryCategory.GetById(product.Category.CategoryId);
                
                if(category != null){
                    prod.Category = category;
                }else
                    return null; //mensagem erro de id categoria não existe

                ICollection<ProductMaterial> icolProdMat = new List<ProductMaterial>();            
            
                foreach(var mt in product.Materials){ //preencher os materiais
                    var material = _repositoryMaterial.GetById(mt.MaterialId);
                    var pM = new ProductMaterial();
                    if(material != null){
                        pM.Material = material;
                        pM.Product = prod;
                        icolProdMat.Add(pM);
                    }
                    else
                        return null; //mensagem erro de id material não existe
                }
                prod.ProductMaterials = icolProdMat;
                
                //distinguir os produtos compostos dos produtos simples

                if(product.SubProducts.Count == 0){
                    _repositoryProduct.Create(prod);
                }else{
                    ICollection<Aggregation> listSubProd = new List<Aggregation>();                               
                    foreach(AggregationDTO aggDTO in product.SubProducts){//preencher os subprodutos
                        Aggregation agg = new Aggregation();

                        //procura pelo id do produto na base de dados
                        var prodSon = _repositoryProduct.GetById(aggDTO.ProductSonId);

                        ICollection<Restriction> restrictions = new List<Restriction>();                        
                        if(prodSon != null){ //verifica se o produto filho é válido 
                            agg.ProductFatherId = aggDTO.ProductFatherId;
                            agg.ProductSonId = aggDTO.ProductSonId;
                            agg.Required = aggDTO.Required;
                            agg.Quantity = aggDTO.Quantity;
                            foreach(int rsttn in aggDTO.Restrictions){
                                Restriction restriction = new Restriction();
                                bool isValid = restriction.CallAlgoritm(product, prodSon,  rsttn, aggDTO.Max, aggDTO.Min);
                                if(isValid){
                                    switch (rsttn){
                                            case (int)EObjectToAlgoritm.Material:
                                                restriction.ObjectToAlgoritm = EObjectToAlgoritm.Material;            
                                                break;
                                            case (int)EObjectToAlgoritm.Dimension:
                                                restriction.ObjectToAlgoritm = EObjectToAlgoritm.Dimension;
                                                break;
                                            case (int)EObjectToAlgoritm.Occupation:
                                                restriction.ObjectToAlgoritm = EObjectToAlgoritm.Occupation; 
                                                break;
                                            default:
                                                break;
                                    }
                                    restrictions.Add(restriction);
                                }else{
                                    return null;
                                }
                            }
                            agg.Restrictions = restrictions;
                            listSubProd.Add(agg);                     
                        }
                        else
                            return null; //mensagem erro que id de sub produto nao existe
                    }
                   
                    prod.ProdSon = listSubProd;
                    _repositoryProduct.Create(prod);
                }
            }else{
                return null;//mensagem erro de produto com o mesmo nome já existe
            }         
            return prod;
    
        }

        public Product UpdateProduct(ProductDTO product){
           
            var prod = _repositoryProduct.GetById(product.ProductId);

            if(prod != null){ //se existir irá actualizar
                 //Verifica se já existe algum produto com o nome passado por parametro
                var p = _repositoryProduct.GetByNameSingle(product.Name);
                if(p == null){
                    prod.Name = product.Name;
                }else{
                    return null;
                }
                prod.WidthMin = product.WidthMin;
                prod.WidthMax = product.WidthMax;
                prod.HeightMin = product.HeightMin;
                prod.HeightMax = product.HeightMax;
                prod.DepthMin = product.DepthMin;
                prod.DepthMax = product.DepthMax;
                prod.Price = product.Price;
                prod.Weight = product.Weight;

                if((product.HeightMin == 0.00) && (product.WidthMin == 0.00) && (product.Weight == 0.00)){
                    prod.DimensionType = IEnumTypeProd.Discreet;
                }else{
                    prod.DimensionType = IEnumTypeProd.Continued;
                }
                
                //valida se o id da categoria passado por parametro existe
                var category = _repositoryCategory.GetById(product.Category.CategoryId);
                if(category != null){
                    prod.Category = category;
                }else
                    return null; //mensagem erro de id categoria não existe

                
                //remover os dados nas tabelas adjacentes para poder alterar
                foreach (ProductMaterial item in prod.ProductMaterials)
                {
                    _repositoryProduct.RemoveProductMaterials(item);
                }

                foreach (Aggregation item in prod.ProdSon)
                {
                    _repositoryProduct.RemoveAggregations(item);
                }

                //validar e adicionar o dados de novo
                ICollection<ProductMaterial> icolProdMat = new List<ProductMaterial>();            
            
                foreach(var mt in product.Materials){ //preencher os materiais
                    var material = _repositoryMaterial.GetById(mt.MaterialId);
                    var pM = new ProductMaterial();
                    if(material != null){
                        pM.Material = material;
                        pM.Product = prod;
                        icolProdMat.Add(pM);
                    }
                    else
                        return null; //mensagem erro de id material não existe
                }
                prod.ProductMaterials = icolProdMat;
                
                //distinguir os produtos compostos dos produtos simples

                if(product.SubProducts.Count == 0){
                    _repositoryProduct.Update(prod);
                }else{
                    ICollection<Aggregation> listSubProd = new List<Aggregation>();                               
                    foreach(AggregationDTO aggDTO in product.SubProducts){//preencher os subprodutos
                        Aggregation agg = new Aggregation();

                        //procura pelo id do produto na base de dados
                        var prodSon = _repositoryProduct.GetById(aggDTO.ProductSonId);

                        ICollection<Restriction> restrictions = new List<Restriction>();                        
                        if(prodSon != null){ //verifica se o produto filho é válido 
                            agg.ProductFatherId = aggDTO.ProductFatherId;
                            agg.ProductSonId = aggDTO.ProductSonId;
                            agg.Required = aggDTO.Required;
                            agg.Quantity = aggDTO.Quantity;
                            foreach(int rsttn in aggDTO.Restrictions){
                                Restriction restriction = new Restriction();
                                bool isValid = restriction.CallAlgoritm(product, prodSon,  rsttn, aggDTO.Max, aggDTO.Min);
                                if(isValid){
                                    switch (rsttn){
                                            case (int)EObjectToAlgoritm.Material:
                                                restriction.ObjectToAlgoritm = EObjectToAlgoritm.Material;            
                                                break;
                                            case (int)EObjectToAlgoritm.Dimension:
                                                restriction.ObjectToAlgoritm = EObjectToAlgoritm.Dimension;
                                                break;
                                            case (int)EObjectToAlgoritm.Occupation:
                                                restriction.ObjectToAlgoritm = EObjectToAlgoritm.Occupation; 
                                                break;
                                            default:
                                                break;
                                    }
                                    restrictions.Add(restriction);
                                }else{
                                    return null;
                                }
                            }
                            agg.Restrictions = restrictions;
                            listSubProd.Add(agg);             
                        }
                        else
                            return null; //mensagem erro que id de sub produto nao existe
                    }
                   
                    prod.ProdSon = listSubProd;
                    _repositoryProduct.Update(prod);
                    
                    return prod;
                    
                }
            }else{
                return null;//mensagem erro de produto com o mesmo nome já existe
            }         
            return null;
        }

        public bool DeleteProduct(ProductDTO product){
            var item = _repositoryProduct.GetById(product.ProductId);

            if (item == null)
            {
                return false;
            }else{
                
                _repositoryProduct.Delete(item);
                
                return true;
            }
            
        }

    }
}