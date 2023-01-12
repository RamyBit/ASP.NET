namespace ZSK_Rechner.Models
{
    public class Waehrungsrechner
    { // fields

        static int preisKuh = 2800;
        static int preisSchaf = 650;
        static int preisZiege = 500;
        static int preisKleineZiege = 50;

        //static int preisDorsch = 8;


        public int Kuh { get; set; }
        public int Schaf { get; set; }
        public int Ziege { get; set; }
        public int KleineZiege { get; set; }
       
        public string Betrag { get; set; }


        // methodes
        static public int[] BerechneEuroInZSK(string betrag)
        {
            int[] erg = new int[4];
            int rest = Convert.ToInt32(betrag);
            // Berechnungen ....
            erg[0] =  rest / preisKuh;
            rest = rest % preisKuh;

            erg[1] = rest / preisSchaf;
            rest = rest % preisSchaf;

            erg[2] = rest / preisZiege;
            rest = rest % preisZiege;

            erg[3] = rest / preisKleineZiege;
            rest = rest % preisKleineZiege;

            return erg;
         
        }

        static public double BerechneZSKInEuro(int kuh, int schaf, int zeige, int klein_zeige)
        {
            double betrag;
            betrag = kuh * preisKuh + schaf * preisSchaf + zeige * preisZiege + klein_zeige * preisKleineZiege;
            return betrag;
        }



    }
}
