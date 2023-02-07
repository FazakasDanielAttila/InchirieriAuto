using System;
using System.Collections.Generic;

namespace InchirieriAuto.Models.DBObjects
{
    public partial class Autovehicule
    {
        public Guid Idautovehicul { get; set; }
        public string Marca { get; set; } = null!;
        public int NumarLocuri { get; set; }
        public bool Disponibilitate { get; set; }
        public decimal PretZi { get; set; }
        public string Valuta { get; set; } = null!;
    }
}
