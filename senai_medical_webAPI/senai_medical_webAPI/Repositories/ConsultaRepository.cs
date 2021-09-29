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
    public class ConsultaRepository : IConsultaRepository
    {
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int id, Consultum consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(x => x.Idconsulta == id);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Consulta.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public void InserirDescricao(int id, Consultum descricao, int idUsuario)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(x => x.Idconsulta == id);

            if (descricao.DescricaoConsulta != null)
            {
                consultaBuscada.DescricaoConsulta = descricao.DescricaoConsulta;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta
           .Include(x => x.IdmedicoNavigation)
           .Include(x => x.IdmedicoNavigation.IdespecialidadeNavigation)
           .Select(x => new Consultum
           {
               Idconsulta = x.Idconsulta,
               IdmedicoNavigation = x.IdmedicoNavigation,
               IdpacienteNavigation = x.IdpacienteNavigation,
               IdsituacaoNavigation = x.IdsituacaoNavigation,
               DescricaoConsulta = x.DescricaoConsulta,
               DataConsulta = x.DataConsulta
           })
           .ToList();
        }

        public List<Consultum> ListarMinhas(int id)
        {
            Paciente pacienteBuscado = ctx.Pacientes.FirstOrDefault(x => x.Idusuario == id);

            Medico medicoBuscado = ctx.Medicos.FirstOrDefault(x => x.Idusuario == id);
            if (pacienteBuscado != null)
            {
                return ctx.Consulta.Where(x => x.Idpaciente == pacienteBuscado.Idpaciente)
                    .Include(x => x.IdpacienteNavigation)
                    .Include(x => x.IdmedicoNavigation)
                    .Include(x => x.IdsituacaoNavigation)
                    .Include(x => x.IdmedicoNavigation.IdespecialidadeNavigation)
                    .Select(x => new Consultum
                    {
                        Idconsulta = x.Idconsulta,
                        IdmedicoNavigation = x.IdmedicoNavigation,
                        IdpacienteNavigation = x.IdpacienteNavigation,
                        IdsituacaoNavigation = x.IdsituacaoNavigation,
                        DescricaoConsulta = x.DescricaoConsulta,
                        DataConsulta = x.DataConsulta
                    })
                   .ToList();
            }
            if (medicoBuscado != null)
            {
                return ctx.Consulta.Include(x => x.IdmedicoNavigation).Where(x => x.Idmedico == medicoBuscado.IDmedico)
                    .Include(x => x.IdpacienteNavigation)
                    .Include(x => x.IdmedicoNavigation)
                    .Include(x => x.IdsituacaoNavigation)
                    .Include(x => x.IdmedicoNavigation.IdespecialidadeNavigation)
                    .Select(x => new Consultum
                    {
                        Idconsulta = x.Idconsulta,
                        IdmedicoNavigation = x.IdmedicoNavigation,
                        IdpacienteNavigation = x.IdpacienteNavigation,
                        IdsituacaoNavigation = x.IdsituacaoNavigation,
                        DescricaoConsulta = x.DescricaoConsulta,
                        DataConsulta = x.DataConsulta

                    })
                    .ToList();
            }

            return null;



        }

        public void StatusConsulta(int id, string status)
        {
            Consultum consultabuscada = ctx.Consulta
                .Include(c => c.IdpacienteNavigation)
                .Include(c => c.IdmedicoNavigation)
                .FirstOrDefault(c => c.Idconsulta == id);

            switch (status)
            {
                case "1":
                    consultabuscada.Idsituacao = 1;
                    break;
                case "2":
                    consultabuscada.Idsituacao = 2;
                    break;

                case "3":
                    consultabuscada.Idsituacao = 3;
                    break;
                default:
                    consultabuscada.Idsituacao = consultabuscada.Idsituacao;
                    break;
            }
            ctx.Consulta.Update(consultabuscada);
            ctx.SaveChanges();
        }

    }
}



