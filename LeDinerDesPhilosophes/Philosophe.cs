using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace LeDinerDesPhilosophes
{
    class Philosophe
    {
        public int ID { get; private set; }
        public string Name { get; set; }

        private bool mort = false;

        public bool ThreadContinue = true;

        Thread thread;
        Dish dish;
        Random rand = new Random();

        public Philosophe(int id, string name, Dish dish)
        {
            ID = id;
            Name = name;
            this.dish = dish;
            
            thread = new Thread(RunThread);
            thread.Name = Name;

            Console.WriteLine($"{Name} s'installe à sa place");
        }

        public void Run()
        {
            thread.Start();
        }

        public void TurnOFFThread()
        {
            thread.Interrupt();
        }

        private void RunThread()
        {
            while (true)
            {
                try
                {
                    // J'ai faim !
                    Eat();

                    if (mort)
                        return;

                    // Je suis repus, je pense !
                    Think();
                    TurnOFFThread();
                }
                catch (ThreadInterruptedException tint)
                {
                    Console.WriteLine("En attente de la fin de l'application");
                    Console.ReadKey(true);
                }
            }
        }

        public void Think()
        {
            Console.WriteLine($"{Name} pense ...");

            Thread.Sleep(rand.Next(1, 3) * 1000);

            Console.WriteLine($"{Name} a fini de penser et a faim !");
        }

        private bool TryTakeBothForks()
        {
            if (dish.LeftFork.TryTake())
            {
                if (dish.RightFork.TryTake())
                    return true;
                else
                    dish.LeftFork.Free();
            }

            return false;
        }

        private void FreeBothForks()
        {
            dish.LeftFork.Free();
            dish.RightFork.Free();
        }

        public void Eat()
        {
            int tpsAttente = 0;
            const int tpsAttenteMax = 4000;

            while (!TryTakeBothForks())
            {
                Thread.Sleep(10);

                tpsAttente += 10;

                if (tpsAttente > tpsAttenteMax)
                {
                    mort = true;
                    Console.WriteLine($"{Name} est MORT !!! Il a attendu {tpsAttente / 1000} secs.");
                    return;
                }
            }

            try
            {
                Console.WriteLine($"{Name} mange ..");
                Thread.Sleep(rand.Next(1, 3) * 1000);
            }
            finally
            {
                FreeBothForks();
            }

            Console.WriteLine($"{Name} est repus. Les fourchettes sont libérées.");
        }
    }
}
