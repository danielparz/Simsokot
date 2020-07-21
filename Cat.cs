using System;
using System.Collections.Generic;
using System.Text;

namespace Simsokot
{
    public class Cat
    {
        public string Name { get; set; }
        public int Food { get; private set; }
        public int Satisfaction { get; private set; }
        public int Torpor { get; private set; }
        public bool IsAsleep { get; private set; }
        private readonly string[] _catNames = new string[]
        {
            "Klakier",
            "Mruczek",
            "Kropka",
            "Kiciuś",
            "Futrzak"
        };
        Random rand = new Random();
        public Cat()
        {
            Name = _catNames[rand.Next(_catNames.Length)];
            Food = 100;
            Satisfaction = 100;
            Torpor = 100;
            IsAsleep = false;
        }        
        private int ChangeProperty(int prop, int val)
        {
            if (prop + val > 100) return 100;
            else if (prop + val < 0) return 0;
            else return prop + val;
        }
        private bool CheckActionSuccess(int chance)
        {
            if (chance >= 100) return true;
            if (chance <= 0) return false;
            return rand.Next(0, 100) < chance;
        }
        private void CheckTorporLvl()
        {
            if(Torpor >= 95)
            {
                IsAsleep = true;
                Console.WriteLine("Kot zasnął.");
                Torpor = ChangeProperty(Torpor, -30);
            }
        }
        public void Brush()
        {
            Console.WriteLine("Próbujesz wyczesać kota.");
            if (IsAsleep)
            {
                IsAsleep = false;
                Satisfaction = ChangeProperty(Satisfaction, -20);
                Food = ChangeProperty(Food, -10);
                Console.WriteLine("Miaauuuu!");
            }
            else
            {
                Satisfaction = CheckActionSuccess(80) ? ChangeProperty(Satisfaction, 30) : ChangeProperty(Satisfaction, -10);
                Food = ChangeProperty(Food, -5);
                Torpor = ChangeProperty(Torpor, 10);
                Console.WriteLine("Mrrrrrr");
                CheckTorporLvl();
            }
        }
        public void Feed()
        {
            Console.WriteLine("Próbujesz nakarmić kota.");
            if(IsAsleep)
            {
                Food = ChangeProperty(Food, -10);
                Satisfaction = ChangeProperty(Satisfaction, -10);
                Torpor = ChangeProperty(Torpor, 5);
                Console.WriteLine("Kot śpi, ale widać, że zapach jedzenia go drażni...");
            }
            else
            {
                Food = ChangeProperty(Food, 30);
                if(CheckActionSuccess(70))
                {
                    Satisfaction = ChangeProperty(Satisfaction, 20);
                    Torpor = ChangeProperty(Torpor, 30);
                    Console.WriteLine("Mrrrrrr");
                }          
                else
                {
                    Satisfaction = ChangeProperty(Satisfaction, -20);
                    Torpor = ChangeProperty(Torpor, 15);
                    Console.WriteLine("Kot nakarmiony, ale macha ogonem.");
                }
            }
            CheckTorporLvl();
        }
        public void Play()
        {
            Console.WriteLine("Próbujesz bawić się z kotem.");
            if (IsAsleep)
            {
                IsAsleep = false;
                Satisfaction = ChangeProperty(Satisfaction, -25);
                Food = ChangeProperty(Food, -15);
                Torpor = ChangeProperty(Torpor, 5);
                Console.WriteLine("Kotu pobudka się nie spodobała...");
            }
            else
            {
                if (CheckActionSuccess(40))
                {
                    Satisfaction = ChangeProperty(Satisfaction, 40);
                    Food = ChangeProperty(Food, -20);
                    Torpor = ChangeProperty(Torpor, 25);
                    Console.WriteLine("Mrrrrrrr");
                }
                else
                {
                    Satisfaction = ChangeProperty(Satisfaction, -25);
                    Food = ChangeProperty(Food, -20);
                    Torpor = ChangeProperty(Torpor, 25);
                    Console.WriteLine("Jak widać kot tej zabawy nie lubi...");
                }
            }
            CheckTorporLvl();
        }
    }
}