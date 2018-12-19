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
        public virtual ICollection<MaterialFinishingDTO> MaterialFinishingsDTO { get; set; }
        public ICollection<FinishingDTO> FinishingsDTO { get; set; }
        
        public MaterialDTO(){}

         public MaterialDTO (int materialId, string name, ICollection<FinishingDTO> finishingsDTO){
            this.MaterialId = materialId;
            this.Name = name;
            this.FinishingsDTO = new List<FinishingDTO>(finishingsDTO);
        }

        public MaterialDTO (int materialId, string name){
            this.MaterialId = materialId;
            this.Name = name;
        }

        public static MaterialDTO From(Material m) {
            var finishings = new List<FinishingDTO>();
            foreach(var mf in m.MaterialFinishings) {
                
                finishings.Add(FinishingDTO.From(mf.Finishing));
            }

            return new MaterialDTO(m.MaterialId, m.Name, finishings);
        }

    }
}