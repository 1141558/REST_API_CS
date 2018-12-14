using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;

namespace nucleocs.Models.Strategy{
    class MaterialAlgoritm : AlgoritmStrategy
    {
        public MaterialAlgoritm(){}

        public override int id { get; set; }

        public override bool isValid(ProductDTO prodFather, Product prodSon)
        {
            List<int> listIdF = new List<int>();
            List<int> listIdS = new List<int>();

            foreach(var mtF in prodFather.Materials){
                listIdF.Add(mtF.MaterialId);
            }

            foreach(var mtS in prodSon.ProductMaterials){
                if(listIdF.Contains(mtS.MaterialId)){
                    return true;
                }
            }

            return false;
        }
    }
}