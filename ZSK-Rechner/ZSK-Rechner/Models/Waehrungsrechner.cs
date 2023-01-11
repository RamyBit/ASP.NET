namespace ZSK_Rechner.Models
{
    public class Waehrungsrechner
    { // fields

        static int preisKuh = 2800;
        static int preisSchaf = 650;
        static int preisZiege = 500;
        static int preisKleineZiege = 50;

        static int preisDorsch = 8;


        //public int BetragInKuh { get; set; }
        //public int BetragInSchaf { get; set; }
        //public int BetragInZiege { get; set; }
        //public int BetragInKZiege { get; set; }
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

      


    }
}
