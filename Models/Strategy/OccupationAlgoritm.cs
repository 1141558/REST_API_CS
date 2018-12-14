using nucleocs.DTO;
using nucleocs.Models;

namespace nucleocs.Models.Strategy{
    class OccupationAlgoritm : AlgoritmStrategy
    {   
        public double Min { get; set; }
        public double Max { get; set; }
        public override int id { get; set; }

        public OccupationAlgoritm(){}

        public OccupationAlgoritm(double max, double min){
            this.Max = max/100;
            this.Min = min/100;
        }

        public override bool isValid(ProductDTO prodFather, Product prodSon)
        {
            bool ok = false;
            double heighMin = prodFather.HeightMin * Min;
            double heighMax = prodFather.HeightMax * Max;
            double widthMax = prodFather.WidthMax * Max;
            double widthMin = prodFather.WidthMin * Min;

            if((prodSon.HeightMin <= heighMin) && (prodSon.HeightMax <= heighMax))
                ok = true;

            if(ok)
                if((prodSon.WidthMin <= widthMin) && (prodSon.WidthMax <= widthMax))
                    return true;

            return false;
        }
    }
}
