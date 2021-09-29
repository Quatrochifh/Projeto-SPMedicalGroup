using senai_medical_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_medical_webAPI.Interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(Consultum novaConsulta);
        List<Consultum> ListarMinhas(int id);
        Consultum BuscarPorId(int id);
        void StatusConsulta(int id, string status);
        void Atualizar(int id, Consultum consultaAtualizada);
        void InserirDescricao(int id, Consultum descricao, int idUsuario);
        void Deletar(int id);
        List<Consultum> Listar();

    }
}
