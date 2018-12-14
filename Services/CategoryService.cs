using System.Collections.Generic;
using System.Linq;
using nucleocs.Data;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;
using nucleocs.Data.Repositories;
using nucleocs.Data.Repositories.Interfaces;
using nucleocs.Services.Interfaces;

namespace nucleocs.Services{
    public class CategoryService : ICategoryService{
       
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public CategoryDTO GetCategoryByID(int id){
            var item = _repository.GetById(id);

            return CategoryDTO.From(item);
        }

        public List<CategoryDTO> GetAllCategories(){

            return _repository.GetAll();
        }

        public List<CategoryDTO> GetCategoryByName(string name){

            return _repository.GetByName(name);
        }

        public CategoryDTO GetCategoryByNameSingle(string name){
            var item = _repository.GetByNameSingle(name);
            
            return CategoryDTO.From(item);
        }

        public Category CreateCategory(CategoryDTO categoryDTO){
            var ctg = new Category();
            var item = _repository.GetByNameSingle(categoryDTO.Name);

            var suCatId = _repository.GetById((categoryDTO.SupCatId).Value);
                                
            if(item == null){
                if(categoryDTO.Name.Length.Equals(null)){
                    return null;
                }else{
                    ctg.Name = categoryDTO.Name;
                } 
               
                if(suCatId != null){
                    ctg.SuperCategoryId = categoryDTO.SupCatId;
                    _repository.Create(ctg);

                    return ctg;
                }
                return null;
            }else{
                return null;
            }

        }

        public Category UpdateCategory(CategoryDTO categoryDTO){
            var category = _repository.GetById(categoryDTO.CategoryId);
            var suCatId = GetCategoryByID((categoryDTO.SupCatId).Value);

            if (category == null)
            {
                return null;
            }else{
                if(suCatId != null){
                    if(categoryDTO.Name.Length.Equals(null)){
                        return null;
                    }else{
                        category.Name = categoryDTO.Name;
                    }                    
                    category.SuperCategoryId = categoryDTO.SupCatId;
                    _repository.Update(category);

                    return category;
                }
                return null;
            }
            
        }

        public bool DeleteCategory(CategoryDTO categoryDTO){

            var item = _repository.GetById(categoryDTO.CategoryId);

            if (item == null)
            {
                return false;
            }else{
                _repository.Delete(item);

                return true;
            }
            
        }

    }
   
}