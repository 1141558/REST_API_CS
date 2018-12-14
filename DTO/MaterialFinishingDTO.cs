using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.DTO
{
    public class MaterialFinishingDTO{
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int FinishingId { get; set; }
        public Finishing Finishing { get; set; } 
        public MaterialFinishingDTO(){}
    }
}