using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nucleocs.DTO
{
    public class AggregationDTO{
        public int ProductFatherId { get; set; }
        public int ProductSonId { get; set; }
        public bool Required { get; set; }
        public ICollection<int> Restrictions { get; set; }
        public int Quantity { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        
        public AggregationDTO(){}
        
    }
}