using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeDinerDesPhilosophes
{
    class Dish
    {
        public Fork LeftFork { get; private set; }
        public Fork RightFork { get; private set; }

        public int Id { get; private set; }

        public Dish(Fork leftFork, Fork rightFork, int id)
        {
            LeftFork = leftFork;
            RightFork = rightFork;
            Id = id;

            Console.WriteLine($"Instanciation de l'assiette {Id}");
        }
    }
}
