using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDDP
{
    class Philosophe
    {
        Action<string> show = s => Console.WriteLine(s);

        Fork rightFork { get; set; }
        Fork leftFork { get; set; }

        public int id;

        public string name;

        Thread thread;

        public Philosophe(int id)
        {
            this.id = id;

            thread = new Thread(StartThread);

            show($"Le philosophe no{id} a été invité");
        }

        public void AttributeCharacteristics(int id, string name, Fork rightFork, Fork leftFork)
        {
            this.id = id;
            this.name = name;
            this.rightFork = rightFork;
            this.leftFork = leftFork;

            show($"{name} est en place");
        }

        public void Run()
        {
            thread.Start();
        }

        private void StartThread()
        {
            while (true)
            {
                Eat();
                Think();
            }
        }

        private void Eat()
        {
            show($"{name} mange...");
            Thread.Sleep(3000);
        }

        private void Think()
        {
            show($"{name} pense...");
            Thread.Sleep(3000);
        }
    }
}
