using System.ComponentModel.DataAnnotations;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class TakmicenjeUcesnik
    {
        public int Id { get; set; }
        public int TakmicenjeId { get; set; }
        public Takmicenje Takmicenje { get; set; }
        public int OdjeljenjeStavkaId { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }
        public bool Pristupio { get; set; }
        [Range(0, 100)]
        public int Bodovi { get; set; }
    }
}
