using System;
using System.Collections.Generic;

namespace InchirieriAuto.Models.DBObjects
{
    public partial class Clienti
    {
        public Guid Idclient { get; set; }
        public string Nume { get; set; } = null!;
        public string Prenume { get; set; } = null!;
        public string Judet { get; set; } = null!;
        public string Oras { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string NumarTelefon { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cnp { get; set; } = null!;
    }
}
