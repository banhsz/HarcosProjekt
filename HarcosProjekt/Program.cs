using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {
        static List<Harcos> harcosok = new List<Harcos>();

        static void HarcosBeolvasas(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev,Encoding.Default);
            while (!sr.EndOfStream)
            {
                string[] seged = sr.ReadLine().Split(';');
                harcosok.Add(new Harcos(seged[0],Convert.ToInt32(seged[1])));
            }
            sr.Close();
        }
        static void HarcosListaKiir(List<Harcos> harcosLista)
        {
            foreach (var item in harcosok)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void Main(string[] args)
        {
            
            harcosok.Add(new Harcos("Garrosh", 2));
            harcosok.Add(new Harcos("Arthas", 1));
            harcosok.Add(new Harcos("Garen", 3));
            HarcosBeolvasas("harcosok.csv");
            HarcosListaKiir(harcosok);





            Console.ReadKey();
        }
    }
}
