using senai_medical_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_medical_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> Listar();
    }
}
