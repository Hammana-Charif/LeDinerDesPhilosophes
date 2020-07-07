using System;
using System.Threading;

namespace LeDinerDesPhilosophes
{
    class Fork
    {
        public int ID { get; set; }

        public Fork(int id)
        {
            ID = id;
            Console.WriteLine($"Instanciation de la fourchette {ID}");
        }

        public bool TryTake() {
            return Monitor.TryEnter(this);
        }

        public void Free()
        {
            Monitor.Exit(this);
        }
    }
}
