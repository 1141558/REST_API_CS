using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.DTO
{
    public class RestrictionDTO{
        public int RestrictionId { get; set; }

        public RestrictionDTO(int restrictionId){
            this.RestrictionId = restrictionId;
        }

        public RestrictionDTO(){}
    }
}