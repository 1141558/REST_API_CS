using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;

namespace nucleocs.DTO
{
    public class AggregationDTO{
        public int ProductFatherId { get; set; }
        public int ProductSonId { get; set; }
        public bool Required { get; set; }
        public ICollection<int> Restrictions { get; set; }
        public ICollection<EObjectToAlgoritm> RestrictionsDTO { get; set; }
        public virtual ICollection<RestrictionDTO> RestrictionsC { get; set; }
        public int Quantity { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        
        public AggregationDTO(){}

        public AggregationDTO(int productSonId, bool required, ICollection<EObjectToAlgoritm> restrictionDTO, int quantity){
            this.ProductSonId = productSonId;
            this.Required = required;
            this.RestrictionsDTO = new List<EObjectToAlgoritm>(restrictionDTO);
            this.Quantity = quantity;
        }

        public static AggregationDTO From(Aggregation a){
            ICollection<EObjectToAlgoritm> restrictions = new List<EObjectToAlgoritm>();

            foreach (var item in a.Restrictions)
            {
                restrictions.Add(item.ObjectToAlgoritm);
            }

            return new AggregationDTO(a.ProductSonId, a.Required, restrictions, a.Quantity);
        }
        
    }
}