using System.Collections.Generic;
using nucleocs.Data.Repositories;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Data.Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        Material GetById(int id);
        List<MaterialDTO> GetAll();
        List<MaterialDTO> GetByName(string name);
        Material GetByNameSingle(string name);
        void Create(Material material);
        void Update(Material material);
        void Delete(Material material);
        ICollection<MaterialFinishing> IcolMtFremove(int id);
        void RemoveMaterialFinishings (MaterialFinishing mT);
    }
}