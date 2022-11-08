using Herupu.DAO.Entidades;
using Herupu.DAO.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Herupu.API.Aprendizado.AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository alunoRepository;

        public AlunoController()
        {
            this.alunoRepository = new AlunoRepository();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Aluno> Get([FromRoute] int id)
        {
            try
            {
                Aluno aluno = alunoRepository.Consultar(id);
                return Ok(aluno);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível consultar o Aluno. Detalhes: {error.Message}" });
            }
        }

        [HttpPost]
        public ActionResult<Aluno> Post([FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                alunoRepository.Inserir(aluno);

                var location = new Uri(Request.GetEncodedUrl() + aluno.IdAluno);

                return Created(location, aluno);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o Aluno. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Aluno> Delete([FromRoute] int id)
        {
            alunoRepository.Excluir(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<Aluno> Put([FromRoute] int id, [FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (aluno.IdAluno != id)
            {
                return NotFound();
            }

            try
            {
                alunoRepository.Alterar(aluno);

                return Ok(aluno);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o Aluno. Detalhes: {error.Message}" });
            }
        }
    }
}
