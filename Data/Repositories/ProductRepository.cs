using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using nucleocs.Data;
using nucleocs.Models;
using nucleocs.MVDTO;
using nucleocs.Data.Repositories.Interfaces;
using nucleocs.DTO;

namespace nucleocs.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly NucleoContext _context;
        public ProductRepository(NucleoContext dataContext) : base(dataContext){
             _context = dataContext;    
        }

        public new Product GetById(int id)
        {
           return _context.Products
                .Include(ps => ps.ProdSon)
                .ThenInclude(p => p.ProductS)
                .Include(ps => ps.ProdSon)
                .ThenInclude(r => r.Restrictions)
                .Include(c => c.Category) 
                .Include(m => m.ProductMaterials)
                .ThenInclude(pm => pm.Material)
                .ThenInclude(mf => mf.MaterialFinishings)
                .ThenInclude(f => f.Finishing)
                .FirstOrDefault(x => x.ProductId == id);
        }

        public List<MVProduct> GetByName(string name)
        {
            var item = _context.Products
                .Include(p => p.ProdSon)
                .ThenInclude(ps => ps.ProductS)
                .Include(p => p.ProdSon)
                .ThenInclude(r => r.Restrictions)
                .Include(c => c.Category) 
                .Include(m => m.ProductMaterials)
                .ThenInclude(pm => pm.Material)
                .ThenInclude(mf => mf.MaterialFinishings)
                .ThenInclude(f => f.Finishing)
                .Where(o => o.Name.Contains(name))
                .Select(p => MVProduct.FromFull(p))
                .ToList();
                
                return item;
        }

         public Product GetByNameSingle(string name)
        {
            return _context.Products
                .Include(p => p.ProdSon)
                .ThenInclude(ps => ps.ProductS)
                .Include(p => p.ProdSon)
                .ThenInclude(r => r.Restrictions)
                .Include(c => c.Category) 
                .Include(m => m.ProductMaterials)
                .ThenInclude(pm => pm.Material)
                .ThenInclude(mf => mf.MaterialFinishings)
                .ThenInclude(f => f.Finishing)
                .FirstOrDefault(x => x.Name == name);
        }

         public new List<MVProduct> GetAll()
        {
            return _context.Products
                .Include(p => p.ProdSon)
                .ThenInclude(ps => ps.ProductS)
                .Include(p => p.ProdSon)
                .ThenInclude(r => r.Restrictions)
                .Include(c => c.Category) 
                .Include(m => m.ProductMaterials)
                .ThenInclude(pm => pm.Material)
                .ThenInclude(mf => mf.MaterialFinishings)
                .ThenInclude(f => f.Finishing)        
                .Select(p => MVProduct.FromFull(p))
                .ToList();
        }

         public void Create(Product product){
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public new void Update(Product product){
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public new void Delete(Product product){
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void RemoveProductMaterials(ProductMaterial item){
            _context.ProductMaterials.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAggregations(Aggregation item){
            _context.Aggregations.Remove(item);
            _context.SaveChanges();
        }

    }
}