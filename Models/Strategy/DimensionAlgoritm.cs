using nucleocs.DTO;
using nucleocs.Models;

namespace nucleocs.Models.Strategy{
    class DimensionAlgoritm : AlgoritmStrategy
    {
        public override int id { get; set; }

        public override bool isValid(ProductDTO prodFather, Product prodSon)
        {
             if((prodFather.HeightMax >= prodSon.HeightMax) && (prodFather.WidthMax >= prodSon.WidthMax) 
                && (prodFather.DepthMax >= prodSon.DepthMax)){
                    return true;
            }          
            return false;
        }
    }
}