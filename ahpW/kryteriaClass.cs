using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahpW
{
   public class kryteriaClass
    {

        public string nazwaKryterium;
        private static int Licznik = 1;
        public int Id { get; set; }
        public kryteriaClass()
        {
            Id++;
            nazwaKryterium = "Nazwa";

        }

        public kryteriaClass(string nazwaKryterium)
        {
            this.Id = Licznik;
            Licznik++;
            this.nazwaKryterium = nazwaKryterium;
        }

    }
}
