using System.Collections.Generic;
using nucleocs.Data.Repositories;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<ProductDTO> GetAll();
        List<ProductDTO> GetByName(string name);
        Product GetByNameSingle(string name);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        void RemoveProductMaterials(ProductMaterial item);
        void RemoveAggregations(Aggregation item);
    }
}