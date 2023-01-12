namespace ZSK_Rechner.Models
{
    public class DAHRSReschner
    {

        //private double dwert;
        //private double awert;
        //private double hwert;
        //private double rwert;
        //private double swert;

        public int Dorsch { get; set; }
        public int Aal { get; set; }
        public int Hering { get; set; }
        public int Rochen { get; set; }
        public int Sprotten { get; set; }

        private static double dwert = 8;
        private static double awert = dwert / 11;
        private static double hwert = awert / 5;
        private static double rwert = 9 * hwert + 7 * awert;
        private static double swert = hwert / 11;
        public int Betrag { get; set; }

        public static int[] EuroInDAHRS(string eingabe)
        {
            double betrag = Convert.ToDouble(eingabe);
            int[] erg = new int[5];
            int d = (int)(betrag / dwert);
            betrag %= dwert;
            int a = (int)(betrag / awert);
            betrag %= awert;
            int h = (int)(betrag / hwert);
            betrag %= hwert;
            int r = (int)(betrag / rwert);
            betrag %= rwert;
            int s = (int)(betrag / swert);
            erg[0] = d;
            erg[1] = a;
            erg[2] = h;
            erg[3] = r;
            erg[4] = s;
            return erg;
            //Console.WriteLine("Der Betrag ist :{0} Dorsch, {1} Aal, {2} Hering, {3} Rochen, {4} Sprotten", d, a, h, r, s);
        }

        public double DAHRSInEuro(int d, int a, int h, int r, int s)
        {
            double betrag;
            betrag = d * dwert + a * awert + h * hwert + r * rwert + s * swert;
            return betrag;
        }
    }
}
