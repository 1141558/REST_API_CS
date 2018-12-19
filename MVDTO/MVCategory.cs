using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.DTO;
using nucleocs.Models;

namespace nucleocs.MVDTO{
    public class MVCategory{
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? SupCatId { get; set; }

        public MVCategory(){}

         public MVCategory(int categoryId, string name, int? supCatId){
            this.Name = name;
            this.CategoryId = categoryId;
            this.SupCatId = supCatId;
        }

        public MVCategory(int categoryId, string name, int? supCatId, string supCatName){
            this.Name = name;
            this.CategoryId = categoryId;
        }

        public static MVCategory From(CategoryDTO c){
            return new MVCategory(c.CategoryId, c.Name, c.SupCatId);
        }
    }
}