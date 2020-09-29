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
            Console.WriteLine(harcos1.ToString());

            Console.ReadKey();
        }
    }
}
