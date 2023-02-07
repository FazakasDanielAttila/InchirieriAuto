using System;
using System.Collections.Generic;

namespace InchirieriAuto.Models.DBObjects
{
    public partial class Angajati
    {
        public Guid Idangajat { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Oras { get; set; } = null!;
        public DateTime DataNasterii { get; set; }
        public string Cnp { get; set; } = null!;
        public string NumarTelefon { get; set; } = null!;
        public string AdresaCompleta { get; set; } = null!;
    }
}
