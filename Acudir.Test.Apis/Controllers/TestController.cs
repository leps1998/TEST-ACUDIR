namespace Acudir.Test.Apis.Controllers
{
    using Acudir.Test.Apis.DTO;
    using Acudir.Test.Apis.Helper;
    using Acudir.Test.Apis.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public TestController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        //Devolver una lista que retorne Personas
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PersonaDTO>>> GetAll([FromQuery] Filter filters)
        {
            var response = await _personaRepository.GetAllPersonas(filters);
            if (response.Any())
            {
                return Ok(response);
            }
            return NotFound();
        }
        //Post Guardar una Persona o mas
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<PersonaAddDTO> personasDto)
        {
            if (personasDto == null || !personasDto.Any())
            {
                return BadRequest("La lista de personas no puede ser nula o estar vacía.");
            }

            var response = await _personaRepository.AddPersonas(personasDto);
            if (response.Any())
            {
                return Ok(response);
            }
            return StatusCode(500, "Error al agregar personas.");
        }

        //Put Modificarlas
        [HttpPut("{nombreCompleto}")]
        public async Task<IActionResult> Put(string nombreCompleto, [FromBody] PersonaUpdateDTO persona)
        {
            if (string.IsNullOrEmpty(nombreCompleto))
            {
                return BadRequest("El parámetro 'nombreCompleto' no puede estar vacío.");
            }

            if (persona == null)
            {
                return BadRequest("La persona no puede ser nula.");
            }

            try
            {
                var response = await _personaRepository.EditPersona(nombreCompleto, persona);
                if (response != null)
                {
                    return Ok(response);
                }
                return NotFound($"Persona '{nombreCompleto}' no encontrada.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno al actualizar la persona.");
            }
        }
    }
}
