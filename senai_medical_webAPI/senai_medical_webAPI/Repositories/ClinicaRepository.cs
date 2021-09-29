using senai_medical_webAPI.Context;
using senai_medical_webAPI.Domains;
using senai_medical_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_medical_webAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        MedicalContext ctx = new MedicalContext();



        public void Cadastrar(Clinica cadastrarClinica)
        {
            ctx.Clinicas.Add(cadastrarClinica);
            ctx.SaveChanges();
        }
    }
}
