using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace snooker
{
    class Snooker
    {
        static void Main(string[] args)
        {
            List<Versenyző> versenyzők = new List<Versenyző>();
                foreach (var sor in File.ReadAllLines("snooker.txt").Skip(1))
            {
                versenyzők.Add(new Versenyző(sor));
            }
            Console.WriteLine(versenyzők[0].Név);
        }
    }
}
