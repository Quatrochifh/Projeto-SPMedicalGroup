using Microsoft.EntityFrameworkCore;
using senai_medical_webAPI.Context;
using senai_medical_webAPI.Domains;
using senai_medical_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_medical_webAPI.Repositories
{
    public class MedicoRepository :IMedicoRepository
    {
        MedicalContext ctx = new MedicalContext();

        List<Medico> IMedicoRepository.Listar()
        {
            return ctx.Medicos.Include(x => x.Consulta).ToList();
        }
    }
}
