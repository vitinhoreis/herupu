using Herupu.DAO.Entidades;
using Herupu.DAO.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Herupu.API.Aprendizado.AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoAlunoController : ControllerBase
    {
        private readonly HistoricoAlunoRepository historicoAlunoRepository;

        public HistoricoAlunoController()
        {
            this.historicoAlunoRepository = new HistoricoAlunoRepository();
        }

        [HttpGet("{id:int}")]
        public ActionResult<HistoricoAluno> Get([FromRoute] int id)
        {
            try
            {
                HistoricoAluno historicoAluno = historicoAlunoRepository.Consultar(id);
                return Ok(historicoAluno);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível consultar o Historico Aluno. Detalhes: {error.Message}" });
            }
        }

        [HttpPost]
        public ActionResult<HistoricoAluno> Post([FromBody] HistoricoAluno historicoAluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                historicoAlunoRepository.Inserir(historicoAluno);

                var location = new Uri(Request.GetEncodedUrl() + historicoAluno.IdHistoricoAluno);

                return Created(location, historicoAluno);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o Historico Aluno. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<HistoricoAluno> Delete([FromRoute] int id)
        {
            historicoAlunoRepository.Excluir(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<HistoricoAluno> Put([FromRoute] int id, [FromBody] HistoricoAluno historicoAluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (historicoAluno.IdHistoricoAluno != id)
            {
                return NotFound();
            }

            try
            {
                historicoAlunoRepository.Alterar(historicoAluno);

                return Ok(historicoAluno);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o Historico Aluno. Detalhes: {error.Message}" });
            }
        }
    }
}
