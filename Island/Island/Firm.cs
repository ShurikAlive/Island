using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island
{
    class Firm: IWork
    {
        private Random rnd;

        public Firm(Random rnd)
        {
            this.rnd = rnd;
        }
    }
}
