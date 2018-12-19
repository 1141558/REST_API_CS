using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;
using nucleocs.Models.Strategy;

namespace nucleocs.DTO
{
    public class RestrictionDTO{

        public int RestrictionId { get; set;}
        public AlgoritmStrategy Algoritm { get; set; }
        public EObjectToAlgoritm ObjectToAlgoritm { get; set; }
        public Aggregation Aggregation { get; set; }

        public RestrictionDTO(int restrictionId){
            this.RestrictionId = restrictionId;
        }

        public RestrictionDTO(){}

        public static RestrictionDTO From(Restriction f) {
            return new RestrictionDTO(f.RestrictionId);
        }
    }
}