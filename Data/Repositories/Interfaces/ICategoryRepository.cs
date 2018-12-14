using System.Collections.Generic;
using nucleocs.Data.Repositories;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        List<CategoryDTO> GetAll();
        List<CategoryDTO> GetByName(string name);
        Category GetByNameSingle(string name);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}