using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.MVDTO
{
    public class MVAggregation{
        public int ProductSonId { get; set; }
        public bool Required { get; set; }
        public ICollection<EObjectToAlgoritm> Restrictions { get; set; }
        public int Quantity { get; set; }
        
        public MVAggregation(){}

        public MVAggregation(int productSonId, bool required, ICollection<EObjectToAlgoritm> restriction, int quantity){
            this.ProductSonId = productSonId;
            this.Required = required;
            this.Restrictions = new List<EObjectToAlgoritm>(restriction);
            this.Quantity = quantity;
        }

        public static MVAggregation From(Aggregation a){
            ICollection<EObjectToAlgoritm> restrictions = new List<EObjectToAlgoritm>();

            foreach (var item in a.Restrictions)
            {
                restrictions.Add(item.ObjectToAlgoritm);
            }

            return new MVAggregation(a.ProductSonId, a.Required, restrictions, a.Quantity);
        }
        
    }
}