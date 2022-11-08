using Herupu.DAO.Entidades;
using Herupu.DAO.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Herupu.API.Aprendizado.AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeItemController : ControllerBase
    {
        private readonly AtividadeItemRepository atividadeItemRepository;

        public AtividadeItemController()
        {
            this.atividadeItemRepository = new AtividadeItemRepository();
        }

        [HttpGet("{id:int}")]
        public ActionResult<AtividadeItem> Get([FromRoute] int id)
        {
            try
            {
                AtividadeItem atividadeItem = atividadeItemRepository.Consultar(id);
                return Ok(atividadeItem);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível consultar a Atividade Item. Detalhes: {error.Message}" });
            }
        }

        [HttpGet("GetAll/{idAtividade:int}")]
        public ActionResult<IEnumerable<AtividadeItem>> GetAll([FromRoute] int idAtividade)
        {
            try
            {
                IEnumerable<AtividadeItem> atividadeItem = atividadeItemRepository.Listar(idAtividade);
                return Ok(atividadeItem);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível consultar a Atividade Item. Detalhes: {error.Message}" });
            }
        }


        [HttpPost]
        public ActionResult<AtividadeItem> Post([FromBody] AtividadeItem atividadeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                atividadeItemRepository.Inserir(atividadeItem);

                var location = new Uri(Request.GetEncodedUrl() + atividadeItem.IdAtividadeItem);

                return Created(location, atividadeItem);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a Atividade Item. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<AtividadeItem> Delete([FromRoute] int id)
        {
            atividadeItemRepository.Excluir(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<AtividadeItem> Put([FromRoute] int id, [FromBody] AtividadeItem atividadeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (atividadeItem.IdAtividadeItem != id)
            {
                return NotFound();
            }

            try
            {
                atividadeItemRepository.Alterar(atividadeItem);

                return Ok(atividadeItem);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a Atividade Item. Detalhes: {error.Message}" });
            }
        }
    }
}
