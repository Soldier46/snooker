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
            // Console.WriteLine(versenyzők[0].Név);
            //3.fealadat
            Console.WriteLine($"3.feladat: A világranglistán {versenyzők.Count} versenyző szerepel.");

            //4.feladat
            double átlag;
            int összeg = 0;
            foreach (var v in versenyzők)
            {
                összeg += v.Nyeremény;
            }
            átlag = (double)összeg / versenyzők.Count;
            Console.WriteLine($"4.feladat A versenyzők átlagosan {átlag:0.00} fontot kerestek");


            //4.  
            Console.WriteLine($"4b.feladat A versenyzők átlagosan {versenyzők.Average(x => x.Nyeremény):0.00} fontot kerestek");

            //5.

            int maxNyer = 0;
            Versenyző maxV = versenyzők[0];
            foreach (var v in versenyzők)
            {
                if (v.Ország == "Kína" && v.Nyeremény > maxV.Nyeremény)
                {
                    maxV = v;
                }

            }
            Console.WriteLine($"legjobban kereső kínai versenyző");
            Console.WriteLine($"\tHelyezés: {maxV.Helyezés}");
            Console.WriteLine($"\tNév: {maxV.Név}");
            Console.WriteLine($"\tOrszág: {maxV.Ország}");
            Console.WriteLine($"\tNyeremény: {(maxV.Nyeremény  * 380).ToString("C0")} ");


            //vagy
            maxV = versenyzők
            .Where(v => v.Ország == "kína")
            .OrderBy(v => v.Nyeremény)
            .Last();
            Console.WriteLine($"legjobban kereső kínai versenyző");
            Console.WriteLine($"\tHelyezés: {maxV.Helyezés}");
            Console.WriteLine($"\tNév: {maxV.Név}");
            Console.WriteLine($"\tOrszág: {maxV.Ország}");
            Console.WriteLine($"\tNyeremény: {(maxV.Nyeremény * 380).ToString("C0")} ");

            //6.a

            bool vanNorvég = false;
            foreach (var v in versenyzők)
            {
                if (v.Ország == "Norvégia")
                {
                    vanNorvég = true;
                }
            }
            Console.WriteLine($"6.feladat: A versenyzok kozott{(vanNorvég ? "van" : "nincs")} van e norveg versenyzo");

            //7.a
            Dictionary<string, int> Stat = new Dictionary<string, int>();
            //Elem (Kulcs-érték pár) hozzáadása
            //Stat.Add("Kína", 20);

            //egy elem létezésének vizsgálata ez 
  //          Stat.ContainsKey("Kína")

                //egy adott kulcshoz tartozó érték használata
                // Stat["Kína"] = 20;
                //   Stat["Kína"]++;
            foreach (var v in versenyzők)
            {
                if (Stat.ContainsKey(v.Ország))
                {
                    Stat[v.Ország]++;
                }
                else
                {
                    Stat.Add(v.Ország, 1);
                }

            }
            Console.WriteLine($"7.feladat: Statisztika");
            foreach (var s in Stat)
            {
                if (s.Value>4)
                {
                    Console.WriteLine($"\t{s.Key} - {s.Value} fő");
                }
            }
            //7.b
            versenyzők
                .GroupBy(v => v.Ország)
                .Select(g => new { Ország = g.Key, darab = g.Count() })
                .Where(x => x.darab > 4)
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Ország}- {x.darab}fő"));
        }
    }
}
