using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        //adattagok
        string nev;
        int szint;
        int tapasztalat;
        int eletero;
        int alapEletero;
        int alapSebzes;

        //konstruktor
        public Harcos(string nev,int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            switch(statuszSablon)
            {
                case 1:
                    this.alapEletero = 15;
                    this.alapSebzes = 3;
                    break;
                case 2:
                    this.alapEletero = 12;
                    this.alapSebzes = 4;
                    break;
                case 3:
                    this.alapEletero = 8;
                    this.alapSebzes = 5;
                    break;
                default:
                    Console.WriteLine("Hibás státuszSablon érték");
                    this.alapEletero = 15;
                    this.alapSebzes = 3;
                    break;
            }
            this.eletero = MaxEletero;
        }

        //get-setterek
        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int AlapEletero { get => alapEletero; }
        public int AlapSebzes { get => alapSebzes; }
        public int Eletero { get => eletero; set => eletero = value; }
        public int Sebzes { get => alapSebzes+szint; }
        public int SzintLepeshez { get => szint*5+10; }
        public int MaxEletero { get => alapEletero + szint*3; }

        //metódusok
        public void Megkuzd(Harcos masikHarcos)
        {

        }
        public void Gyogyul()
        {

        }
        public override string ToString()
        {
            return String.Format("");
        }
    }
}
