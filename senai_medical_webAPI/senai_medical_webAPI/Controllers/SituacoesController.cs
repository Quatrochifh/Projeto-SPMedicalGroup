using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_medical_webAPI.Interfaces;
using senai_medical_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_medical_webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    //http://localhost:5000/api/situacoes

    [ApiController]
    public class SituacoesController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository;
        public SituacoesController()
        {
            _situacaoRepository = new SituacaoRepository();
        }


        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_situacaoRepository.Listar());
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
