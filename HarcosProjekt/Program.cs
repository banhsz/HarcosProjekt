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
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());
            harcos1.Megkuzd(harcos2);
            Console.WriteLine();
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());
            harcos1.Megkuzd(harcos2);
            Console.WriteLine();
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());
            harcos1.Megkuzd(harcos2);
            Console.WriteLine();
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());
            harcos1.Megkuzd(harcos2);
            Console.WriteLine();
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());
            harcos1.Megkuzd(harcos2);
            Console.WriteLine();
            Console.WriteLine(harcos1.ToString());
            Console.WriteLine(harcos2.ToString());

            Console.ReadKey();
        }
    }
}
