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
                    this.alapEletero = 15;
                    this.alapSebzes = 3;
                    break;
            }
            this.eletero = MaxEletero;
        }

        //get-setterek
        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat
        { 
            get => tapasztalat; 
            set
            {
                if ((value)>=(SzintLepeshez))
                {
                    tapasztalat = value;
                    tapasztalat -= SzintLepeshez;
                    Szint++;
                    Eletero = MaxEletero;
                }
                else
                {
                    tapasztalat = value;
                }
            }
        }
        public int AlapEletero { get => alapEletero; }
        public int AlapSebzes { get => alapSebzes; }
        public int Eletero 
        {
            get => eletero;
            set
            {
                if (value<=0)
                {
                    eletero = 0;
                    Tapasztalat = 0;
                }
                else if (value>MaxEletero)
                {
                    eletero = MaxEletero;
                }
                else
                {
                    eletero = value;
                }
            }
        
        }
        public int Sebzes { get => alapSebzes+szint; }
        public int SzintLepeshez { get => szint*5+10; }
        public int MaxEletero { get => alapEletero + szint*3; }

        //metódusok
        public void Megkuzd(Harcos masikHarcos)
        {
            if (masikHarcos==this)
            {
                Console.WriteLine("Saját magadat nem tudod támadni.");
            }
            else if (Eletero==0 || masikHarcos.Eletero==0)
            {
                Console.WriteLine("Legalább az egyik harcos halott");
            }
            else
            {
                //a kihívó támadja a másikat
                masikHarcos.Eletero -= Sebzes;

                //ha a megtámadott még él
                if (masikHarcos.Eletero>0)
                {
                    Eletero -= masikHarcos.Sebzes;
                }

                //tapasztalati pont kiértékelés
                if (Eletero==0)
                //harcos 1 meghalt
                {
                    if (masikHarcos.Eletero>0)
                    {
                        //Harcos 1 meghalt,Harcos 2 él
                        masikHarcos.Tapasztalat += 15;
                    }
                    //else
                    // {
                        //Harcos 1 meghalt,Harcos 2 él
                    // }
                }
                else 
                //harcos 1 él
                {
                    if (masikHarcos.Eletero > 0)
                    {
                        //Harcos 1 él, Harcos 2 él
                        Tapasztalat += 5;
                        masikHarcos.Tapasztalat += 5;
                    }
                    else
                    {
                        //Harcos 1 él, Harcos 2 meghalt
                        Tapasztalat += 15;
                    }

                }

            }
        }
        public void Gyogyul()
        {
            if (Eletero==0)
            {
                Eletero = MaxEletero;
            }
            else
            {
                Eletero += 3 + Szint;
            }
        }
        public override string ToString()
        {
            return String.Format("{0,-10} - LVL:{1} - EXP: {2}/{3} - HP: " +
                "{4}/{5} - DMG: {6}",this.Nev,this.Szint,this.Tapasztalat,
                this.SzintLepeshez,this.Eletero,this.MaxEletero,this.Sebzes);
        }
    }
}
