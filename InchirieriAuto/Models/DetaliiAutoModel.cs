using System.ComponentModel.DataAnnotations;

namespace InchirieriAuto.Models
{
    public class DetaliiAutoModel
    {
        public Guid IDDetaliiAuto { get; set; }
        public string Caroserie { get; set; }
        public string NumarInmatriculare { get; set; }

        [DataType(DataType.Date)]
        public DateTime AnFabricatie { get; set; }

        public string Combutisbil { get; set; }

        public string CutieViteze { get; set; }

        public string CapacitateCilindrica { get; set; }

    }
}
