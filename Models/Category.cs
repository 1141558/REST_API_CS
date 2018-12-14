using System.Collections.Generic;

namespace nucleocs.Models
{
    public class Category{
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? SuperCategoryId { get; set; }
        public virtual ICollection<Product> Products { get; set; }//Categoty tem muitos Products
        public Category (){}
    }
}