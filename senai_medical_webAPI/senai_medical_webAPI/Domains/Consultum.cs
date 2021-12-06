using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_medical_webAPI.Domains
{
    public partial class Consultum
    {
        public int Idconsulta { get; set; }

        [Required(ErrorMessage = "O médico é obrigatório")]
        public int? Idmedico { get; set; }
        public int? Idpaciente { get; set; }
        public int? Idsituacao { get; set; }

        [Required(ErrorMessage = "a Data é obrigatório")]
        public DateTime DataConsulta { get; set; }
        public string DescricaoConsulta { get; set; }

        public virtual Medico IdmedicoNavigation { get; set; }
        public virtual Paciente IdpacienteNavigation { get; set; }
        public virtual Situacao IdsituacaoNavigation { get; set; }
    }
}
