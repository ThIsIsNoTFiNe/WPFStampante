using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marconi.nicholas._4i.stampante.Models
{
    public class Pagina
    {
        public int Ciano { get; set; }
        public int Magenta { get; set; }
        public int Yellow { get; set; }
        public int Black { get; set; }

        //costruttore che accetta al massimo colori di valore 3
        public Pagina(int c, int m, int y, int b) 
        {
            /*
            if (c > 3 || m > 3 || y > 3 || b > 3)
            {
                throw new ArgumentException("I valori dei colori devono essere al massimo 3.");
            }
            */

            Ciano = c;
            Magenta = m;
            Yellow = y;
            Black = b;
        }

        //costruttore che crea una pagina
        public Pagina()
        {
            Random rand = new Random();
            Ciano = rand.Next(4);
            Magenta = rand.Next(4);
            Yellow = rand.Next(4);
            Black = rand.Next(4);
        }
    }
}
