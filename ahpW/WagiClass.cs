using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahpW
{
   public class WagiClass
    {
        public int Id;
        public kryteriaClass k1;
        public kryteriaClass k2;
        public double waga;

        public WagiClass(int Id, kryteriaClass k1, kryteriaClass k2, double waga) {
            this.Id = Id;
            this.k1 = k1;
            this.k2 = k2;
            this.waga = waga;
        }

    }
}
