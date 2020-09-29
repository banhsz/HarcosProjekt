using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Harcos harcos1 = new Harcos("Garrosh",2);
            Harcos harcos2 = new Harcos("Arthas",1);

            //harcteszt
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(harcos1.ToString());
                Console.WriteLine(harcos2.ToString());
                harcos1.Megkuzd(harcos2);
            }

            //gyogyulasteszt
            Console.WriteLine();
            harcos2.Gyogyul();
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());

            harcos1.Gyogyul();
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
