using Herupu.DAO.Entidades;
using Herupu.DAO.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Herupu.API.Aprendizado.AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly AtividadeRepository atividadeRepository;

        public AtividadeController()
        {
            this.atividadeRepository = new AtividadeRepository();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Atividade> Get([FromRoute] int id)
        {
            try
            {
                Atividade atividade = atividadeRepository.Consultar(id);
                return Ok(atividade);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível consultar a Atividade. Detalhes: {error.Message}" });
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<Atividade> GetAll()
        {
            try
            {
                IEnumerable<Atividade> atividade = atividadeRepository.Listar();
                return Ok(atividade);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível consultar a Atividade. Detalhes: {error.Message}" });
            }
        }


        [HttpPost]
        public ActionResult<Atividade> Post([FromBody] Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                atividadeRepository.Inserir(atividade);

                var location = new Uri(Request.GetEncodedUrl() + atividade.IdAtividade);

                return Created(location, atividade);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a Atividade. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Atividade> Delete([FromRoute] int id)
        {
            atividadeRepository.Excluir(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<Atividade> Put([FromRoute] int id, [FromBody] Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (atividade.IdAtividade != id)
            {
                return NotFound();
            }

            try
            {
                atividadeRepository.Alterar(atividade);

                return Ok(atividade);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a Atividade. Detalhes: {error.Message}" });
            }
        }
    }
}
