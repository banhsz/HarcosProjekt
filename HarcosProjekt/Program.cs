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
            int i = 0;
            foreach (var item in harcosok)
            {
                Console.WriteLine(String.Format((i+1)+". "+item.ToString()));
                i++;
            }
        }
        static void HarcosListaInit()
        {
            harcosok.Add(new Harcos("Garrosh", 2));
            harcosok.Add(new Harcos("Arthas", 1));
            harcosok.Add(new Harcos("Garen", 3));
            HarcosBeolvasas("harcosok.csv");
        }
        static void FelhasznaloHarcosBekeres()
        {
            Console.WriteLine("Mi legyen a harcosod neve?");
            String nev = Console.ReadLine();
            Console.WriteLine("Mi legyen a státusz sablonja?");
            Console.WriteLine("1: Alap életerő = 15, Alap sebzés = 3\n2: Alap életerő = 12, Alap sebzés = 4\n3: Alap életerő = 8, Alap sebzés = 5");
            int sablon;
            try
            {
                sablon = Convert.ToInt32(Console.ReadLine());
                if (sablon<1 || sablon>3)
                {
                    Console.WriteLine("Érvénytelen. 1-esre lett beállítva.");
                    sablon = 1;
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Érvénytelen. 1-esre lett beállítva.");
                sablon = 1;
            }
            harcosok.Add(new Harcos(nev,sablon));
            HarcosListaKiir(harcosok);
            Console.WriteLine("Nyomj egy gombot a folytatáshoz");
            Console.ReadKey();
            Console.Clear();
             
        }
        static void Jatek()
        {
            int korokSzama = 1;
            bool jatekMegy = true;
            while (jatekMegy)
            {
                int parancs = -1;
                while (!(parancs >= 1 && parancs <= 3))
                {
                    Console.Clear();
                    HarcosListaKiir(harcosok);
                    Console.WriteLine("Mit szeretnél csinálni?");
                    Console.WriteLine("1. Megküzdeni egy harcossal\n2. Gyógyulni\n3. Kilépni");
                    parancs = Convert.ToInt32(Console.ReadLine());
                }
                switch (parancs)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.WriteLine("Kiléptél");
                        jatekMegy = false;
                        break;
                    default:
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            HarcosListaInit();
            FelhasznaloHarcosBekeres();
            Jatek();





            Console.ReadKey();
        }
    }
}
