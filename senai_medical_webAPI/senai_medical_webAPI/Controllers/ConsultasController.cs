using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_medical_webAPI.Domains;
using senai_medical_webAPI.Interfaces;
using senai_medical_webAPI.Repositories;
using senai_medical_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_medical_webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    //http://localhost:5000/api/consultas

    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet("listartodas")]
        public IActionResult ListaTodas()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }

        /// Lista todas as consultas de um usuario
        [Authorize(Roles = "2, 3")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(id));
            }
            catch (Exception erro)
            {

                return BadRequest(new
                {
                    mensagem = "Se não estiver logado, não sera possivel mostrar as consultas!",
                    erro
                });
            }

        }


        [Authorize(Roles = "1, 2")]
        [HttpPost]
        public IActionResult Post(Consultum novaConsulta)
        {

            _consultaRepository.Cadastrar(novaConsulta);


            return StatusCode(201);
        }

        //Ira atualizar a situação da consulta
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]

        public IActionResult UpdateConsulta(int id, Consultum status)
        {
            try
            {
                _consultaRepository.StatusConsulta(id, status.Idsituacao.ToString());

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //Ira atualizar a descrição da consulta
        [Authorize(Roles = "2")]
        [HttpPut("descricao/{id}")]
        public IActionResult PutDesc(int id, ConsultumViewModel descricaoAtualizado)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Consultum consultaBuscada = _consultaRepository.BuscarPorId(id);

                if (consultaBuscada != null)
                {
                    consultaBuscada = new Consultum
                    {
                        DescricaoConsulta = descricaoAtualizado.descricao
                    };

                    _consultaRepository.InserirDescricao(id, consultaBuscada, idUsuario);

                    return StatusCode(204);
                }
                return BadRequest("Nenhuma consulta foi encontrada encontrada! tente novamente");
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _consultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
