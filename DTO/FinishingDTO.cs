using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.DTO
{
    public class FinishingDTO{
        public int FinishingId { get; set; }
        public string Name { get; set; }

        public FinishingDTO(){}
    }
}