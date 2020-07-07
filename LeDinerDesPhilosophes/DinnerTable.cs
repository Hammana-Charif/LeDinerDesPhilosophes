using System;

namespace LeDinerDesPhilosophes
{
    class DinnerTable
    {
        protected Philosophe Philosophe1;
        protected Philosophe Philosophe2;
        protected Philosophe Philosophe3;
        protected Philosophe Philosophe4;
        protected Philosophe Philosophe5;

        protected Dish Dish1;
        protected Dish Dish2;
        protected Dish Dish3;
        protected Dish Dish4;
        protected Dish Dish5;

        protected Fork Fork1;
        protected Fork Fork2;
        protected Fork Fork3;
        protected Fork Fork4;
        protected Fork Fork5;

        public void Start()
        {
            MakeATable();

            Console.WriteLine("Début du repas");

            Philosophe1.Run();
            Philosophe2.Run();
            Philosophe3.Run();
            Philosophe4.Run();
            Philosophe5.Run();

            //Console.WriteLine("En attente de la fin de l'application");
            //Console.ReadKey(true);
        }

        public void MakeATable()
        {
            Console.WriteLine("Mise en place de la table :");
            Fork1 = new Fork(1);
            Fork2 = new Fork(2);
            Fork3 = new Fork(3);
            Fork4 = new Fork(4);
            Fork5 = new Fork(5);

            Console.WriteLine("___________________________________");

            Dish1 = new Dish(Fork1, Fork2, 1);
            Dish2 = new Dish(Fork2, Fork3, 2);
            Dish3 = new Dish(Fork3, Fork4, 3);
            Dish4 = new Dish(Fork4, Fork5, 4);
            Dish5 = new Dish(Fork5, Fork1, 5);

            Console.WriteLine("___________________________________");

            Philosophe1 = new Philosophe(1, "Platon", Dish1);
            Philosophe2 = new Philosophe(2, "Socrate", Dish2);
            Philosophe3 = new Philosophe(3, "Descartes", Dish3);
            Philosophe4 = new Philosophe(4, "Marx", Dish4);
            Philosophe5 = new Philosophe(5, "Sartre", Dish5);

            Console.WriteLine("___________________________________");
        }
    }
}
