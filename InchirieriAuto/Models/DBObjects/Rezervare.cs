using System;
using System.Collections.Generic;

namespace InchirieriAuto.Models.DBObjects
{
    public partial class Rezervare
    {
        public Guid Idrezervare { get; set; }

        public string Nume { get; set; }    
        public string NumarTelefon { get; set; } 
        public DateTime DataPreluare { get; set; }
        public DateTime DataReturnare { get; set; }
        
    }
}
