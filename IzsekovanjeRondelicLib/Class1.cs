using System;
using System.Collections.Generic;

namespace IzsekovanjeRondelicLib
{
    public class Rondelica
    {
        int xPos; // x pozicija na traku
        int yPos; // y pozicija na traku
    }

    public class OkroglaRondelica : Rondelica
    {
        double r; // polmer okrogle rondelice
    }

    public class IzsekovanjeRondelic
    {

        /// <param name="dolzinaTraku">Dolzina traku podana v milimetrih</param>
        /// <param name="sirinaTraku">Sirina traku podana v milimetrih</param>
        /// <param name="polmer">Polmer rondelice podan v milimetrih</param>
        /// <param name="razMedSos">Razdalja med sosednjima rondelicama, podana v milimetrih</param>
        /// <param name="razMedStran">Razdalja med rondelico in robom traku, podana v milimetrih</param>
        public List<OkroglaRondelica> Izracunaj(double dolzinaTraku, double sirinaTraku, double polmer, double razMedSos, double razMedStran)
        {
            List<OkroglaRondelica> ret = new List<OkroglaRondelica>();

            // Začetno preverjanje, da niso vhodni podatki napačni
            double prviTest = 2 * polmer + 2 * razMedStran;
            if (prviTest > sirinaTraku
                || prviTest > dolzinaTraku)
                return ret; // v tem primeru se vrne seznam z 0 elementi



            return ret;
        }
    }
}
