using System.Collections.Generic;
using System.Data;
using System.Linq;
using nucleocs.Data;
using nucleocs.Models;
using nucleocs.MVDTO;
using nucleocs.Data.Repositories;
using nucleocs.DTO;
using nucleocs.Data.Repositories.Interfaces;

namespace nucleocs.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly NucleoContext _context;
        public CategoryRepository(NucleoContext dataContext) : base(dataContext){
             _context = dataContext;    
        }
        public new Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

         public new List<MVCategory> GetAll(){
            return _context.Categories
                .Select(c => MVCategory.From(c))
                .ToList();
        }

        public List<MVCategory> GetByName(string name){

            return _context.Categories
                .Where(o => o.Name.Contains(name))
                .Select(m => MVCategory.From(m))
                .ToList();
        }

        public Category GetByNameSingle(string name){

            return _context.Categories
                .SingleOrDefault(p => p.Name.Equals(name));
        }

        public void Create(Category category){
             _context.Categories.Add(category);
             _context.SaveChanges();
        }

        public new void Update(Category category){
             _context.Categories.Update(category);
             _context.SaveChanges();
        }

        public new void Delete(Category category){
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

    }
}