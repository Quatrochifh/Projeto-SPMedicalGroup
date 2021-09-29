using System;
using System.Collections.Generic;

#nullable disable

namespace senai_medical_webAPI.Domains
{
    public partial class Consultum
    {
        public int Idconsulta { get; set; }
        public int? Idmedico { get; set; }
        public int? Idpaciente { get; set; }
        public int? Idsituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }

        public virtual Medico IdmedicoNavigation { get; set; }
        public virtual Paciente IdpacienteNavigation { get; set; }
        public virtual Situacao IdsituacaoNavigation { get; set; }
    }
}
