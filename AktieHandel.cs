namespace ClassLibraryAktieHandel
{
    public class AktieHandel    
    {
        private string navn;

        /// <summary>
        /// unik id for handel
        /// </summary>
        public int HandelsId { get; set; }

        /// <summary>
        /// navn på aktien
        /// </summary>
        public string Navn
        {
            get
            {
                return navn;
            }
            set
            {
                if (value == null || value.Length <= 3)
                {
                    throw new ArgumentException("Navn skal mindst være fire tegn langt og må ikke være null");
                }
                else
                    navn = value;
            }
        }
        /// <summary>
        /// antal aktier der er handlet
        /// Antal er positivt ved et aktiekøb
        /// Antal er negativt ved et aktiesalg
        /// </summary>
        public int Antal { get; set; }
        /// <summary>
        /// prisen for den enkelte aktie
        /// </summary>
        public Decimal HandelsPris { get; set; }

        public override string? ToString()
        {
            return ($"HandelsId:{HandelsId}, Navn: {Navn}, Antal: {Antal}, Handelspris:{HandelsPris}");
        }
    }


}
