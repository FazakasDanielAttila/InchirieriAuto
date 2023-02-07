using System;
using System.Collections.Generic;

namespace InchirieriAuto.Models.DBObjects
{
    public partial class DetaliiAuto
    {
        public Guid IddetaliiAuto { get; set; }
        public string Caroserie { get; set; } = null!;
        public string NumarInmatriculare { get; set; } = null!;
        public DateTime AnFabricatie { get; set; }
        public string Combustibil { get; set; } = null!;
        public string CutieViteze { get; set; } = null!;
        public string CapacitateCilindrica { get; set; } = null!;
    }
}
