using System.Collections.Generic;
using nucleocs.Data.Repositories;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Data.Repositories.Interfaces
{
    public interface IFinishingRepository
    {
        Finishing GetById(int id);
        List<FinishingDTO> GetAll();
        List<FinishingDTO> GetByName(string name);
        Finishing GetByNameSingle(string name);
        void Create(Finishing finishing);
        void Update(Finishing finishing);
        void Delete(Finishing finishing);
    }
}