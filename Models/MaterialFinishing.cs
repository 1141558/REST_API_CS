using System.ComponentModel.DataAnnotations.Schema;

namespace nucleocs.Models{
    public class MaterialFinishing
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int FinishingId { get; set; }
        public Finishing Finishing { get; set; }   
        public MaterialFinishing(){}
        
    }
}