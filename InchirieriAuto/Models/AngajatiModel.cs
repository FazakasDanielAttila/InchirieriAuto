using System.ComponentModel.DataAnnotations;

namespace InchirieriAuto.Models
{
    public class AngajatiModel
    {
        public Guid IDAngajat { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Oras { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }
        public string CNP { get; set; }
        public string NumarTelefon { get; set; }
        public string AdresaCompleta { get; set; }


    }
}
