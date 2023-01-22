using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;   

namespace nir_tar3.DTO
{
    public class recepieDTO
    {
        public int id;
        public string name;
        public string image;
        public string cookingMethod;
        public double time;
        public List <IngridientDto> Ingridients;
        

    }
}