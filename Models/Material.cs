using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace nucleocs.Models
{
    public class Material{
      public int MaterialId { get; set; }
      public string Name { get; set; }
      public virtual ICollection<MaterialFinishing> MaterialFinishings { get; set; }
      public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }
      public Material(){
        this.MaterialFinishings = new HashSet<MaterialFinishing>();
        this.ProductMaterials = new HashSet<ProductMaterial>();
      }
    }

}