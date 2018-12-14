using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.MVDTO{
    public class MVFinishing{
        public int FinishingId { get; set; }
        public string Name { get; set; }

        public MVFinishing(string name, int finishingId){
            this.Name = name;
            this.FinishingId = finishingId;
        }

        public MVFinishing(){}

        public static MVFinishing From(Finishing f) {
            return new MVFinishing(f.Name, f.FinishingId);
        }
    }
}