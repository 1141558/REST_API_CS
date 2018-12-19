using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.DTO;
using nucleocs.Models;

namespace nucleocs.MVDTO{
    public class MVMaterial{
        public int MaterialId  { get; set; }
        public string Name { get; set; }
        public ICollection<FinishingDTO> Finishings { get; set; }
        public ICollection<MVFinishing> MVFinishings { get; set; }
        public MVMaterial(){}

        public MVMaterial (int materialId, string name, ICollection<MVFinishing> finishingsMV){
            this.MaterialId = materialId;
            this.Name = name;
            this.MVFinishings = new List<MVFinishing>(finishingsMV);
        }

        public MVMaterial (int materialId, string name){
            this.MaterialId = materialId;
            this.Name = name;
        }

        public static MVMaterial From(MaterialDTO m) {
            var finishings = new List<MVFinishing>();
            
            foreach(var mf in m.MaterialFinishingsDTO) {
                
                finishings.Add(MVFinishing.From(mf.FinishingD));
            }

            return new MVMaterial(m.MaterialId, m.Name, finishings);
        }

        public static MVMaterial FromLitle(Material m) {
            return new MVMaterial(m.MaterialId, m.Name);
        }
    }
}