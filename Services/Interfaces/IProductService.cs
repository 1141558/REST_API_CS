using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface IProductService{
        List<MVProduct> GetAllProducts();
        Product GetProductByID(int id);
        List<MVProduct> GetProductByName(string name);
        Product GetProductByNameSingle(string name);
        Product GetProductParts(ProductDTO prod);
        Product CreateLitleProduct(ProductDTO product);
        Product CreateFullProduct(ProductDTO product);
        Product UpdateProduct(ProductDTO product);
        bool DeleteProduct(ProductDTO product);
    }
}