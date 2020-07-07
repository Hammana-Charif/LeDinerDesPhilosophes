using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDDP
{
    class DinnerTable
    {
        Action<string> show = s => Console.WriteLine(s);

        Fork[] forks;
        public Fork[] Forks { get
            {
                if (forks == null)
                    forks = GetForks();

                return forks;
            }
        }


        Philosophe[] philosophes;
        public Philosophe[] Philosophes { get
            {
                if (philosophes == null)
                    philosophes = InvitePhilosophes();

                return philosophes;
            }
        }

        private Fork[] GetForks()
        {
            List<Fork> forks = new List<Fork>();

            for (int id = 1; id <= 5; id++)
            {
               forks.Add(new Fork(id));
            }

            return forks.ToArray();
        }

        private Philosophe[] InvitePhilosophes()
        {
            List<Philosophe> philosophes = new List<Philosophe>();

            for (int id = 1; id <= 5; id++)
            {
                philosophes.Add(new Philosophe(id));
            }

            return philosophes.ToArray();
        }

        private void PlaceGuests()
        {
            Philosophes[0].AttributeCharacteristics(1, "Platon", Forks[0], Forks[1]);
            Philosophes[1].AttributeCharacteristics(2, "Socrate", Forks[1], Forks[2]);
            Philosophes[2].AttributeCharacteristics(3, "Descartes", Forks[2], Forks[3]);
            Philosophes[3].AttributeCharacteristics(4, "Marx", Forks[3], Forks[4]);
            Philosophes[4].AttributeCharacteristics(5, "Sartres", Forks[4], Forks[0]);
        }

        private void MakeATable()
        {
            GetForks();
            InvitePhilosophes();
            PlaceGuests();
        }

        public void Start()
        {
            show("Début du repas");
            MakeATable();

            for (int index = 0; index < Philosophes.Length; index++)
            {
                Philosophes[index].Run();
            }
        }
    }
}
