using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface ICategoryService{

        Category GetCategoryByID(int id);
        List<MVCategory> GetAllCategories();
        List<MVCategory> GetCategoryByName(string name);
        Category GetCategoryByNameSingle(string name);
        Category CreateCategory(CategoryDTO categoryDTO);
        Category UpdateCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(CategoryDTO categoryDTO);
    }
}