using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAktieHandel
{
    public class AktieHandelRepository : IAktieHandelRepository
    {
        private List<AktieHandel> _aktieHandelList = new List<AktieHandel>()
        {
        new AktieHandel() {HandelsId=1,Navn="Novo",Antal=100, HandelsPris=300.0m },
        new AktieHandel() {HandelsId=2,Navn="Novo",Antal=100, HandelsPris=300.0m },
        new AktieHandel() {HandelsId=3,Navn="Novo",Antal=150, HandelsPris=350.0m },
        new AktieHandel() {HandelsId=4,Navn="Novo",Antal=-100, HandelsPris=200.0m },
        };

        public IEnumerable<AktieHandel> GetAll()
        {
            return _aktieHandelList;
        }

        /// <summary>
        /// henter en enkeltaktiehandel ud fra handelsid
        /// </summary>
        /// <param name="handelsId">det id som skal findes i listen</param>
        /// <returns>et AktieHandel object med det pågældende handelsid eller null hvis handelsid ikke findes</returns>
        public AktieHandel? GetById(int handelsId)
        {
            return _aktieHandelList.FirstOrDefault(x => x.HandelsId == handelsId);
        }

        /// <summary>
        /// tilføjer en aktiehandel til listen 
        /// </summary>
        /// <param name="aktieHandel">det aktiehandels objekt som skal indsættes i listen</param>
        /// <returns>det objekt som er indsat i listen</returns>
        public AktieHandel AddAktieHandel(AktieHandel aktieHandel)
        {
            _aktieHandelList.Add(aktieHandel);
            return aktieHandel;
        }


        /// <summary>
        /// opdaterer en eksisterende AktieHandels objekt i listen med det pågældende handelsid 
        /// med et nyt AktieHandels objekt
        /// </summary>
        /// <param name="ny_aktieHandel">Det nye data som der skal opdateres med</param>
        /// <returns>det opdaterede AktieHandelsObjekt</returns>
        public AktieHandel UpdateAktieHandel(AktieHandel ny_aktieHandel)
        {
            var gammel_aktieHandel = this.GetById(ny_aktieHandel.HandelsId);

            if(gammel_aktieHandel != null)
            {
                gammel_aktieHandel.Antal = ny_aktieHandel.Antal;
                gammel_aktieHandel.Navn = ny_aktieHandel.Navn;
                gammel_aktieHandel.HandelsPris = ny_aktieHandel.HandelsPris;
            }
            
            gammel_aktieHandel = ny_aktieHandel;
            return ny_aktieHandel;
        }

        /// <summary>
        /// Sletter et AktieHandels objekt fra listen med det pågældende
        /// handelsid. 
        /// </summary>
        /// <param name="handelsid">handelsid på det objekt som skal slettes</param>
        /// <returns>det slettede AktieHandelsobjekt eller null hvis det ikke findes</returns>
        public AktieHandel? DeleteAktieHandel(int handelsid)
        {
            var aktieHandel = this.GetById(handelsid);
            if(aktieHandel != null)
              _aktieHandelList.Remove(aktieHandel);
            
            return aktieHandel;
        }

        public IEnumerable<AktieHandel> GetAktieHandlerByNavn(string navn) { 
         return _aktieHandelList.FindAll(x => x.Navn == navn);
        }

        public IEnumerable<AktieHandel> GetAllAktieHandlerSortedByAntal()
        {
            return _aktieHandelList.OrderBy(x => x.Antal).ToList();
        }

    }
}
