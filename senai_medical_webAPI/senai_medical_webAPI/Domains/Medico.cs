using System;
using System.Collections.Generic;

#nullable disable

namespace senai_medical_webAPI.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IDmedico { get; set; }
        public int? Idusuario { get; set; }
        public int? Idespecialidade { get; set; }
        public int? Idclinica { get; set; }
        public string NomeMedico { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdclinicaNavigation { get; set; }
        public virtual Especialidade IdespecialidadeNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
