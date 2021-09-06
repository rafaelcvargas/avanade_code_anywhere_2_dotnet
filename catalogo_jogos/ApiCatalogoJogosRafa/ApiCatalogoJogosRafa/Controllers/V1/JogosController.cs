using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogosRafa.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Obter()
        {
            //Todo: continuar 

            return Ok();
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<List<object>>> Obter(Guid idJogo)
        {
            //Todo: continuar 

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<List<object>>> InserirJogo() 
        {
            //Todo: continuar 
            return Ok();
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo,object jogo)
        {
            //Todo: continuar 
            return Ok();
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            //Todo: continuar 
            return Ok();
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            //Todo: continuar 
            return Ok();
        }
    }
}
