using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.DTO
{
     public class MaterialDTO{
        public int MaterialId  { get; set; }
        public string Name { get; set; }
        public List<int> FinishingId { get; set; }
        public ICollection<Finishing> Finishings { get; set; }
        
        public MaterialDTO(){}
    }
}