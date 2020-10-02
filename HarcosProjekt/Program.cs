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
            Console.ReadLine();
            Console.Clear();
             
        }
        static void Jatek()
        {
            Random rand = new Random();
            int korokSzama = 1;
            bool jatekMegy = true;
            while (jatekMegy)
            {
                int parancs = -1;
                while (!(parancs >= 1 && parancs <= 3))
                {
                    Console.Clear();
                    HarcosListaKiir(harcosok);
                    if (korokSzama%3==0)
                    {
                        //Ez azért kell mert ha nincs élő ellenfél akkor senki ne támadja meg a játékost
                        //Ezt úgy teszteltem hogy kiszedtem a 3. körönkénti gyógyulást így sose éledtek újra
                        List<int> halottHarcosok = new List<int>();
                        bool vanEloEllenfel = false;
                        int randomHarcos = -1;
                        while (!vanEloEllenfel && halottHarcosok.Count<harcosok.Count - 1)
                        {
                            randomHarcos = rand.Next(harcosok.Count - 1);
                            if (harcosok[randomHarcos].Eletero==0)
                            {
                                halottHarcosok.Add(randomHarcos);
                            }
                            else
                            {
                                vanEloEllenfel = true;
                            }

                        }
                        if (vanEloEllenfel)
                        {
                            //ha 6 harcos van 0 és 5 között ad számokat, de az utolsó a játékos ugyhogy harcosok.count-1
                            //
                            Console.WriteLine("\n{0}. kör, {1} harcos támadja {2} harcost", korokSzama, harcosok[randomHarcos].Nev, harcosok[harcosok.Count - 1].Nev);
                            harcosok[randomHarcos].Megkuzd(harcosok[harcosok.Count - 1]);
                            Console.WriteLine(harcosok[randomHarcos].ToString());
                            Console.WriteLine(harcosok[harcosok.Count - 1].ToString());
                        }
                        else
                        {
                            Console.WriteLine("\n{0}. kör, nincs élő ellenfél", korokSzama);
                        }
                        Console.WriteLine("\nMinden harcos gyógyul");
                        foreach (Harcos item in harcosok)
                        {
                            item.Gyogyul();
                        }
                        HarcosListaKiir(harcosok);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\n{0}. kör", korokSzama);
                    }
                    Console.WriteLine("Mit szeretnél csinálni?");
                    Console.WriteLine("1. Megküzdeni egy harcossal\n2. Gyógyulni\n3. Kilépni");
                    parancs = Convert.ToInt32(Console.ReadLine());
                }
                switch (parancs)
                {
                    case 1:
                        if (harcosok[harcosok.Count - 1].Eletero>0)
                        {
                            int kivel = -1;
                            while (kivel < 1 || kivel > harcosok.Count() - 1 || harcosok[kivel - 1].Eletero == 0)
                            //harcosok.Count()-1 mert ő van a végén saját magával ne küzdjön meg
                            {
                                Console.WriteLine("Kivel szeretnél megküzdeni?");
                                kivel = Convert.ToInt32(Console.ReadLine());
                                if (kivel < 1 || kivel > harcosok.Count() - 1)
                                {
                                    Console.WriteLine("Nincs ilyen számú harcos vagy magaddal akarsz megküzdeni");
                                }
                                else if (harcosok[kivel - 1].Eletero == 0)
                                {
                                    Console.WriteLine("Ez a harcos halott");
                                }
                            }
                            Console.WriteLine("Megküzdesz {0} harcossal", harcosok[kivel - 1].Nev);
                            //igazából kivel-1 -el az indexelés miatt
                            harcosok[harcosok.Count - 1].Megkuzd(harcosok[kivel - 1]);
                            Console.WriteLine(harcosok[harcosok.Count - 1].ToString());
                            Console.WriteLine(harcosok[kivel - 1].ToString());
                            Console.WriteLine("Nyomj egy gombot a folytatáshoz");
                            Console.ReadKey();
                            korokSzama++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" ! Meg vagy halva ! ");
                            Console.WriteLine("Nyomj egy gombot a folytatáshoz");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        Console.WriteLine("Gyógyulsz");
                        harcosok[harcosok.Count - 1].Gyogyul();
                        Console.WriteLine(harcosok[harcosok.Count - 1].ToString());
                        Console.WriteLine("Nyomj egy gombot a folytatáshoz");
                        Console.ReadLine();
                        korokSzama++;
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





            Console.ReadLine();
        }
    }
}
