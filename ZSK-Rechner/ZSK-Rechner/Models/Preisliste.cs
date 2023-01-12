namespace ZSK_Rechner.Models
{
    public class Preisliste
    {
        private Preis[] arrayVonPreisObjekten = new Preis[10];
        int pos = 0;
        public void setPreisliste(string bez, int preis)
        {
            Preis p = new Preis();
            p.setPreis(bez, preis);
            arrayVonPreisObjekten[pos] = p;
            pos++;

        }
        //public Preis[] getPreisliste()
        //{
        //    return arrayVonPreisObjekten;
        //}
    }
}
