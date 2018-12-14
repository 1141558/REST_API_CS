using nucleocs.DTO;
using nucleocs.Models;
namespace nucleocs.Models.Strategy{
    public abstract class AlgoritmStrategy
    {
        public abstract int id { get; set; }
        abstract public bool isValid(ProductDTO prodFather, Product prodSon);
    }
}