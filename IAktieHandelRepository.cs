
namespace ClassLibraryAktieHandel
{
    public interface IAktieHandelRepository
    {
        AktieHandel? DeleteAktieHandel(int handelsid);
        IEnumerable<AktieHandel> GetAll();
        AktieHandel? GetById(int handelsId);
        AktieHandel AddAktieHandel(AktieHandel aktieHandel);
        AktieHandel UpdateAktieHandel(AktieHandel ny_aktieHandel);

        //filtrering
        public IEnumerable<AktieHandel> GetAktieHandlerByNavn(string navn);

        //sortering
        public IEnumerable<AktieHandel> GetAllAktieHandlerSortedByAntal();

    }
}