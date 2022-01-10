using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snooker
{
    class Versenyző
    {
        public int Helyezés { get; set; }     //PROP  TAb taB 
        public String Név { get; set; }
        public string Ország { get; set; }
        public int Nyeremény { get; set; }



        public Versenyző(string sor)
        {
            string[] t =  sor.Split(';');
            Helyezés =int.Parse( t[0]);
            Név = t[1];
            Ország = t[2];
                Nyeremény =int.Parse(t[3]);
        }
    }
}
