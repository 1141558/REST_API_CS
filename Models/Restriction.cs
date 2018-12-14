using nucleocs.DTO;
using nucleocs.Models.Strategy;


namespace nucleocs.Models
{
    public class Restriction{
        public int RestrictionId { get; set;}
        public AlgoritmStrategy Algoritm { get; set; }
        public EObjectToAlgoritm ObjectToAlgoritm { get; set; }
        public Aggregation Aggregation { get; set; }
        
        public Restriction(){}
        public Restriction(AlgoritmStrategy Algoritm){
            this.Algoritm = Algoritm;
        }

        public bool CallAlgoritm(ProductDTO father, Product son, int choice, double max, double min){
            bool isValid = false;
            switch (choice)
            {
                case (int)EObjectToAlgoritm.Material:
                    isValid = new MaterialAlgoritm().isValid(father, son);            
                    break;
                case (int)EObjectToAlgoritm.Dimension:
                    isValid = new DimensionAlgoritm().isValid(father, son);
                    break;
                case (int)EObjectToAlgoritm.Occupation:
                    isValid = new OccupationAlgoritm(max, min).isValid(father, son); 
                    break;
                default:
                    break;
            }

            return isValid;
        }     
    }
}