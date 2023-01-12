namespace ZSK_Rechner.Models
{
    class Preis
    {
        private string bezeichnung;
        private int preis;

        public void setPreis(string bezeichnung, int preis)
        {
            this.bezeichnung = bezeichnung;
            this.preis = preis;
        }
        public string getBezeichnung()
        {
            return bezeichnung;
        }
        public int getPreis()
        {
            return preis;
        }
    }
}
