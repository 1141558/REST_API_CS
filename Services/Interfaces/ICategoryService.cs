using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface ICategoryService{

        CategoryDTO GetCategoryByID(int id);
        List<CategoryDTO> GetAllCategories();
        List<CategoryDTO> GetCategoryByName(string name);
        CategoryDTO GetCategoryByNameSingle(string name);
        Category CreateCategory(CategoryDTO categoryDTO);
        Category UpdateCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(CategoryDTO categoryDTO);
    }
}