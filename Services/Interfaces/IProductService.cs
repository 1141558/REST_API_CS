using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface IProductService{
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductByID(int id);
        List<ProductDTO> GetProductByName(string name);
        ProductDTO GetProductByNameSingle(string name);
        //ProductDTO GetProductParts(ProductDTO prod);
        ProductDTO CreateLitleProduct(ProductDTO product);
        ProductDTO CreateFullProduct(ProductDTO product);
        ProductDTO UpdateProduct(ProductDTO product);
        bool DeleteProduct(ProductDTO product);
    }
}