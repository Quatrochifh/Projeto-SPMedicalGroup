using System;
using System.Collections.Generic;

#nullable disable

namespace senai_medical_webAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int Idpaciente { get; set; }
        public int? Idusuario { get; set; }
        public string NomePac { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereço { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
