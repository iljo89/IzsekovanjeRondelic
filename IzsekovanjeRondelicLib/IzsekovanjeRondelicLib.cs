using System;
using System.Collections.Generic;

namespace IzsekovanjeRondelicLib
{
    public class Rondelica
    {
        public double XPos // x pozicija na traku
        {
            set;
            get;
        }
        public double YPos // y pozicija na traku
        {
            set;
            get;
        }

        public Rondelica(double x, double y)
        {
            this.XPos = x;
            this.YPos = y;
        }
    }

    public class OkroglaRondelica : Rondelica
    {
        public double RRond // polmer okrogle rondelice
        {
            set;
            get;
        }

        /// <param name="xPos">Pozicija na x poziciji (dolzina) traku</param>
        /// <param name="yPos">Pozicija na y poziciji (sirina) traku</param>
        /// <param name="rRond">Polmer rondelice</param>
        public OkroglaRondelica(double xPos, double yPos, double rRond) : base (xPos, yPos)
        {
            this.RRond = rRond;
        }

        public bool SeDotika(OkroglaRondelica rond)
        {
            return false;
        }
        
    }

    public class IzsekovanjeRondelic
    {
        /// <summary>
        /// Vrne true, ce lahko algoritem nadaljuje, oz. false, ce ne sme
        /// </summary>
        /// <param name="polmer">Polmer rondelice podan v milimetrih</param>
        /// <param name="razMedStran">Razdalja med rondelico in robom traku, podana v milimetrih</param>
        /// <param name="sirinaTraku">Sirina traku podana v milimetrih</param>
        /// <param name="dolzinaTraku">Dolzina traku podana v milimetrih</param>
        /// <returns></returns>
        private bool PrviTest(double polmer, double razMedStran, double sirinaTraku, double dolzinaTraku)
        {
            // Začetno preverjanje, da niso vhodni podatki napačni
            double prviTest = 2 * polmer + 2 * razMedStran; // Premer vključno z razdaljo med rondelico in stranico na vsaki strani
            if (prviTest > sirinaTraku
                || prviTest > dolzinaTraku)
                return false; // v tem primeru se vrne seznam z 0 elementi
            else
                return true;
        }

        private bool PostaviRondelico(List<OkroglaRondelica> ret, ref OkroglaRondelica rond, double sirinaTraku, double dolzinaTraku, double razMedSos, double razMedStran, ref bool gorAliDol)
        {
            if(gorAliDol) // true - gremo visje, false - gremo nizje
            {
                rond.YPos += 2 * rond.RRond + razMedSos;
                double zgMeja = rond.YPos + rond.RRond + razMedStran;
                if (zgMeja > sirinaTraku) // v visino vec ne gre, smo prek traku
                {
                    rond.YPos = sirinaTraku - rond.RRond - razMedStran;
                    gorAliDol = false;
                }
                else // na trak gre po sirini vec rondelic
                    return true;
            }

            else
            {
                rond.YPos -= 2 * rond.RRond + razMedSos;
                double spMeja = rond.YPos - rond.RRond - razMedStran;
                if (spMeja < 0) // ne gre vec nizje, smo prek traku
                {
                    rond.YPos = rond.RRond + razMedStran;
                    gorAliDol = true;
                }
                else
                    return true;
            }
            return true;
        }

        /// <param name="dolzinaTraku">Dolzina traku podana v milimetrih</param>
        /// <param name="sirinaTraku">Sirina traku podana v milimetrih</param>
        /// <param name="polmer">Polmer rondelice podan v milimetrih</param>
        /// <param name="razMedSos">Razdalja med sosednjima rondelicama, podana v milimetrih</param>
        /// <param name="razMedStran">Razdalja med rondelico in robom traku, podana v milimetrih</param>
        public List<OkroglaRondelica> Izracunaj(double dolzinaTraku, double sirinaTraku, double polmer, double razMedSos, double razMedStran)
        {
            List<OkroglaRondelica> ret = new List<OkroglaRondelica>();

            if (PrviTest(polmer, razMedStran, sirinaTraku, dolzinaTraku) == false)
                return ret;

            double x = polmer + razMedStran;    // koordinate prve rondelice na traku
            double y = x;                       //
            OkroglaRondelica rond = new OkroglaRondelica(x, y, polmer);
            ret.Add(rond);
            bool postavljena = false; // Spremenljivka za glavno zanko, true, dokler je možno postaviti rondelico na trak
            bool gorAliDol = true; // true, da postavlja rondelice visje, false, da jih postavlja nizje

            do
            {
                rond = new OkroglaRondelica(x, y, polmer);
                postavljena = PostaviRondelico(ret, ref rond, sirinaTraku, dolzinaTraku,razMedSos, razMedStran,ref gorAliDol);
            } while (postavljena);

            return ret;
        }
    }
}
