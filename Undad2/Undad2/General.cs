using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Undad2;

namespace Undad2
{
    class General
    {


        public Double aleatorio()
        {

            Random num = new Random();
            Random dec = new Random();
            string cadena = num.Next(0, 0).ToString() + "." + dec.Next(0, 99).ToString();
            double final = Convert.ToDouble(cadena);

            
            return final;
        }
    }
}
