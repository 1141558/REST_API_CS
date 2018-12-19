using System.Collections.Generic;
using System.Data;
using System.Linq;
using nucleocs.Data;
using nucleocs.Data.Repositories.Interfaces;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Data.Repositories
{
    public class FinishingRepository : Repository<Finishing>, IFinishingRepository
    {
        private readonly NucleoContext _context;
        public FinishingRepository(NucleoContext dataContext) : base(dataContext){
             _context = dataContext;    
        }
        public new Finishing GetById(int id)
        {
            var item = _context.Finishings.Find(id);
            return item;
        }

         public new List<FinishingDTO> GetAll(){
            return _context.Finishings
                .Select(f => FinishingDTO.From(f))
                .ToList();
        }

        public List<FinishingDTO> GetByName(string name){

            return _context.Finishings
                .Where(o => o.Name.Contains(name))
                .Select(m => FinishingDTO.From(m))
                .ToList();
        }

        public Finishing GetByNameSingle(string name){

            var item = _context.Finishings
                .SingleOrDefault(p => p.Name.Equals(name));
            return item;
        }

        public void Create(Finishing finishing){
             _context.Finishings.Add(finishing);
             _context.SaveChanges();
        }

        public new void Update(Finishing finishing){
             _context.Finishings.Update(finishing);
             _context.SaveChanges();
        }

        public new void Delete(Finishing finishing){
            _context.Finishings.Remove(finishing);
            _context.SaveChanges();
        }
    }
}