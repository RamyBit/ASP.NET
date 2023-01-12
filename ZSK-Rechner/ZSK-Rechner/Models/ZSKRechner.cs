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

        private static int klein_zeige_preis = 50;
        private static int zeige_preis = 500;
        private static int schaf_preis = 650;
        private static int kuh_preis = 2 * schaf_preis + 3 * zeige_preis;

        private static int kuh_menge = 2;
        private static int schaf_menge = 4;
        private static int zeige_menge = 5;
        private static int kleinen_zeigen_menge = 6;


        //public void updatePreis(Preisliste preisliste)
        //{
        //    Preis[] preis = preisliste.getPreisliste();
        //    kuh_preis = preis[0].getPreis();
        //    schaf_preis = preis[1].getPreis();
        //    zeige_preis = preis[2].getPreis();
        //    klein_zeige_preis = preis[3].getPreis();

        //}
        public static int[] EuroInZSK(double betrag)
        {
            int[] erg = new int[5];
            int substituten = 0;
            double subswert = 0;
            int kuh = (int)(betrag / kuh_preis);
            if (kuh > kuh_menge)
            {
                substituten = kuh - kuh_menge;
                subswert = (double)(substituten * kuh_preis);
                kuh = kuh_menge;
            }
            betrag %= kuh_preis;
            betrag += subswert;
            int schaf = (int)((betrag) / schaf_preis);
            if (schaf > schaf_menge)
            {
                substituten = 0;
                substituten = schaf - schaf_menge;
                subswert = 0;
                subswert = (double)(substituten * schaf_preis);
            }
            betrag %= schaf_preis;
            betrag += subswert;
            int zeige = (int)(betrag / zeige_preis);
            if (schaf > schaf_menge)
            {
                substituten = 0;
                substituten = zeige - zeige_menge;
                subswert = 0;
                subswert = (double)(substituten * zeige_preis);
            }
            betrag %= zeige_preis;

            int klein_zeige = (int)(betrag / klein_zeige_preis);
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
            betrag = kuh * kuh_preis + schaf * schaf_preis + zeige * zeige_preis + klein_zeige * klein_zeige_preis;
            return betrag;
        }
    }
}
