using System;
using System.Collections.Generic;

#nullable disable

namespace senai_medical_webAPI.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdtipoUsuario { get; set; }
        public string PerfisDeUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
