using System.ComponentModel.DataAnnotations;

namespace InchirieriAuto.Models
{
    public class RezervareModel
    {
        public Guid IDRezervare { get; set; }

        public string Nume { get; set; }
        public string NumarTelefon { get; set; }

       // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataPreluare { get; set; }

       // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataReturnare { get; set; }
        

    }
}
