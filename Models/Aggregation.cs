using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models.Strategy;

namespace nucleocs.Models
{
    public class Aggregation{

        public int ProductFatherId { get; set; }
        public Product ProductF { get; set; }
        public int ProductSonId { get; set; }
        public Product ProductS { get; set; }
        public bool Required { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Restriction> Restrictions { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        public Aggregation(){
            this.Restrictions = new List<Restriction>();    
        }
    }
    
}