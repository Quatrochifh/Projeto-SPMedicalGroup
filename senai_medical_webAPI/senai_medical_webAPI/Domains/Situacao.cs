using System;
using System.Collections.Generic;

#nullable disable

namespace senai_medical_webAPI.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int Idsituacao { get; set; }
        public string QualSituacao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
