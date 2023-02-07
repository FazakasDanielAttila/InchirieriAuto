using System;
using System.Collections.Generic;

namespace InchirieriAuto.Models.DBObjects
{
    public partial class Agentie
    {
        public Guid Idagentie { get; set; }
        public string NumeAgentie { get; set; } = null!;
        public string Judet { get; set; } = null!;
        public string Oras { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string NumarTelefon { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
