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
    public class SituacaoRepository : ISituacaoRepository
    {
        MedicalContext ctx = new MedicalContext();
        List<Situacao> ISituacaoRepository.Listar()
        {
            return ctx.Situacaos.Include(x => x.Consulta).ToList();
        }
    }
}
