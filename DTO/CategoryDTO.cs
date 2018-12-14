using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.DTO
{
    public class CategoryDTO{
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? SupCatId { get; set; }

        public CategoryDTO(){}

        public CategoryDTO(int categoryId, string name, int? supCatId){
        this.Name = name;
        this.CategoryId = categoryId;
        }

        public static CategoryDTO From(Category c){
            return new CategoryDTO(c.CategoryId, c.Name, c.SuperCategoryId);
        }
    }
}