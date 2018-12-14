using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.MVDTO{
    public class MVMaterial{
        public int MaterialId  { get; set; }
        public string Name { get; set; }
        public ICollection<MVFinishing> Finishings { get; set; }
        public MVMaterial(){}

        public MVMaterial (int materialId, string name, ICollection<MVFinishing> finishings){
            this.MaterialId = materialId;
            this.Name = name;
            this.Finishings = new List<MVFinishing>(finishings);
        }

        public MVMaterial (int materialId, string name){
            this.MaterialId = materialId;
            this.Name = name;
        }

        public static MVMaterial From(Material m) {
            var finishings = new List<MVFinishing>();
            foreach(var mf in m.MaterialFinishings) {
                
                finishings.Add(MVFinishing.From(mf.Finishing));
            }

            return new MVMaterial(m.MaterialId, m.Name, finishings);
        }

        public static MVMaterial FromLitle(Material m) {
            return new MVMaterial(m.MaterialId, m.Name);
        }
    }
}