using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing;

namespace ZSK_Rechner.Models
{
    public class ZSKRechner
    {
        //private int klein_zeige_preis;
        //private int zeige_preis;
        //private int schaf_preis;
        //private int kuh_preis;

        //private int kuh_menge;
        //private int schaf_menge;
        //private int zeige_menge;
        //private int kleinen_zeigen_menge;

        private static int kleinZeigePreis;// = 50;
        private static int ziegePreis; //= 500;
        private static int schafPreis; //= 650;
        private static int kuhPreis; //= 2 * schaf_preis + 3 * zeige_preis;

        private static int kuhMenge; //= 2;
        private static int schafMenge; //= 4;
        private static int ziegeMenge; //= 5;
        private static int kleineZiegeMenge; // = 6;

        //public void updatePreis(Preisliste preisliste)
        //{
        //    Preis[] preis = preisliste.getPreisliste();
        //    kuh_preis = preis[0].getPreis();
        //    schaf_preis = preis[1].getPreis();
        //    zeige_preis = preis[2].getPreis();
        //    klein_zeige_preis = preis[3].getPreis();

        //}
        public static void SetPreis(string kZPreis,
                            string zPreis,
                            string sPreis,
                            string kPreis)
        {
            kleinZeigePreis = Convert.ToInt32(kZPreis);
            ziegePreis = Convert.ToInt32(zPreis);
            schafPreis = Convert.ToInt32(sPreis);
            kuhPreis = Convert.ToInt32(kPreis);
        }

        public static void SetMenge(string kMenge,
                                    string sMenge,
                                    string zMenge,
                                    string kZMenge)
        {
            kuhMenge = Convert.ToInt32(kMenge);
            schafMenge = Convert.ToInt32(sMenge);
            ziegeMenge = Convert.ToInt32(zMenge);
            kleineZiegeMenge = Convert.ToInt32(kZMenge);
        }
        public static int[] EuroInZSK(double betrag)
        {
            int[] erg = new int[5];
            int substituten = 0;
            double subswert = 0;
            int kuh = (int)(betrag / kuhPreis);
            if (kuh > kuhMenge)
            {
                substituten = kuh - kuhMenge;
                subswert = (double)(substituten * kuhPreis);
                kuh = kuhMenge;
            }
            betrag %= kuhPreis;
            betrag += subswert;
            int schaf = (int)((betrag) / schafPreis);
            if (schaf > schafMenge)
            {
                substituten = 0;
                substituten = schaf - schafMenge;
                subswert = 0;
                subswert = (double)(substituten * schafPreis);
            }
            betrag %= schafPreis;
            betrag += subswert;
            int zeige = (int)(betrag / ziegePreis);
            if (schaf > schafMenge)
            {
                substituten = 0;
                substituten = zeige - ziegeMenge;
                subswert = 0;
                subswert = (double)(substituten * ziegePreis);
            }
            betrag %= ziegePreis;

            int klein_zeige = (int)(betrag / kleinZeigePreis);
            erg[0] = kuh;
            erg[1] = schaf;
            erg[2] = zeige;
            erg[3] = klein_zeige;
            return erg;
            //Console.WriteLine("Der Betrag ist :{0} kuh, {1} shaf, {2} zeige, {3} kleinen Zeigen",kuh, schaf, zeige, klein_zeige);
        }

        public double ZSKInEuro(int kuh, int schaf, int zeige, int klein_zeige)
        {
            double betrag;
            betrag = kuh * kuhPreis + schaf * schafPreis + zeige * ziegePreis + klein_zeige * kleinZeigePreis;
            return betrag;
        }
    }
}
