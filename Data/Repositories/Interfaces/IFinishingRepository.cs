using System.Collections.Generic;
using nucleocs.Data.Repositories;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Data.Repositories.Interfaces
{
    public interface IFinishingRepository
    {
        Finishing GetById(int id);
        List<MVFinishing> GetAll();
        List<MVFinishing> GetByName(string name);
        Finishing GetByNameSingle(string name);
        void Create(Finishing finishing);
        void Update(Finishing finishing);
        void Delete(Finishing finishing);
    }
}