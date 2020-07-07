using System;
using System.Collections.Generic;
using System.Text;

namespace LDDP
{
    class Fork
    {
        public int id = 0;

        public bool occuped { get; private set; }
        
        public Fork(int id)
        {
            this.id = id;

            Console.WriteLine($"Fourchette no{id} a été récupérée");
        }
    }
}
