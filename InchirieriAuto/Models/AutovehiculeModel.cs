namespace InchirieriAuto.Models
{
    public class AutovehiculeModel
    {
        public Guid IDAutovehicul { get; set; }
        public string Marca { get; set; }
        public int NumarLocuri { get; set; }
        public bool Disponibilitate { get; set; }
        public decimal PretZi { get; set; }
        public string Valuta { get; set; }

    }
}
