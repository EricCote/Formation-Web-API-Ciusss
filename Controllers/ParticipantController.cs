using Ciusss.Models;
using Ciusss.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ciusss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private CoursDbContext _ctx;

        public ParticipantController(CoursDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/<ParticipantController>
        [HttpGet]
        [HttpGet("/api/participants")]
        [HttpGet("/api/attendees")]
        public async Task<IEnumerable<ParticipantDTO>> Get()
        {
            return await _ctx.Participants.
                Select(p => ParticipantToDTO(p)).
                ToListAsync<ParticipantDTO>();
        }

        // GET api/<ParticipantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantDTO>> Get(int id)
        {
            try
            {
                if (id == 13)
                {
                    throw new Exception("C'est pas un chiffre permis!");
                }
                var p = await _ctx.Participants.FirstAsync(p => p.Id == id);
                return ParticipantToDTO(p);
            }
            catch (InvalidOperationException)
            {

                return NotFound();
            }
            //catch (Exception ex)
            //{
            //    return Problem(title: ex.Message, statusCode: 500);
            //}

        }

        // POST api/<ParticipantController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ParticipantDTO nouveau)
        {
          
            Participant p = new Participant
            {
                Id = nouveau.Id,
                Nom = nouveau.Nom,
                Prenom = nouveau.Prenom,
                Salaire = 0
            };

            _ctx.Participants.Add(p);
            await _ctx.SaveChangesAsync();

            var actionName = nameof(Get);
            return CreatedAtAction(actionName, new { id = p.Id }, ParticipantToDTO(p));
        }

        // PUT api/<ParticipantController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Participant modifie)
        {
            Participant p =  await _ctx.Participants.FirstAsync(p => p.Id == id);
            p.Prenom = modifie.Prenom;
            p.Nom = modifie.Nom;
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<ParticipantController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Participant p = await _ctx.Participants.FirstAsync(p => p.Id == id);
            _ctx.Participants.Remove(p);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        private static ParticipantDTO ParticipantToDTO(Participant p)
        {
            return new ParticipantDTO
            {
                Id = p.Id,
                Prenom = p.Prenom,
                Nom = p.Nom
            };
        }
    }
}

