using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace nucleocs.Models
{
    public class Finishing
    {
        public int FinishingId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MaterialFinishing> MaterialFinishings { get; set; }
        public Finishing(){
            this.MaterialFinishings = new List<MaterialFinishing>();
        }
    }

}