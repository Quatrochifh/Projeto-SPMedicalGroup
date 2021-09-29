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
    public class UsuarioRepository : IUsuarioRepository
    {
        MedicalContext ctx = new MedicalContext();
        public Usuario Logar(string email, string senha)
        {
            return ctx.Usuarios.Include(h => h.IdtipoUsuarioNavigation).FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
