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
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private readonly NucleoContext _context;
        public MaterialRepository(NucleoContext dataContext) : base(dataContext){
             _context = dataContext;    
        }
        public new Material GetById(int id)
        {
            return _context.Materials
                    .Include(f => f.MaterialFinishings)
                    .ThenInclude(mf => mf.Finishing)
                    .FirstOrDefault(x => x.MaterialId == id);
        }

         public new List<MVMaterial> GetAll(){
            return _context.Materials
                .Include(f => f.MaterialFinishings)
                .ThenInclude(mf => mf.Finishing)
                .Select(m => MVMaterial.From(m))
                .ToList();
        }

        public List<MVMaterial> GetByName(string name){
           return _context.Materials
                    .Include(f => f.MaterialFinishings)
                    .ThenInclude(mf => mf.Finishing)
                    .Where(o => o.Name.Contains(name))
                    .Select(m => MVMaterial.From(m))
                    .ToList();
        }

        public Material GetByNameSingle(string name){
          return _context.Materials
            .Include(f => f.MaterialFinishings)
            .FirstOrDefault<Material>(m => m.Name.Equals(name));
        }

        public void Create(Material material){
             _context.Materials.Add(material);
             _context.SaveChanges();
        }

        public new void Update(Material material){
             _context.Materials.Update(material);
             _context.SaveChanges();
        }

        public new void Delete(Material material){
            _context.Materials.Remove(material);
            _context.SaveChanges();
        }

        public ICollection<MaterialFinishing> IcolMtFremove(int id){
            return _context.MaterialFinishings
                            .Where(x => x.MaterialId == id)
                            .ToList();
        }

        public void RemoveMaterialFinishings (MaterialFinishing mT){
            _context.MaterialFinishings.Remove(mT);
            _context.SaveChanges();
        }

    }
}