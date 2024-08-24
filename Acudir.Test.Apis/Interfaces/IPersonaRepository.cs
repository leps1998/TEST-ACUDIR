using Acudir.Test.Apis.DTO;
using Acudir.Test.Apis.Helper;

namespace Acudir.Test.Apis.Interfaces
{
    public interface IPersonaRepository
    {
        Task<List<PersonaDTO>> GetAllPersonas(Filter filters);
        Task<List<PersonaDTO>> AddPersonas(List<PersonaAddDTO> personasAdd);
        Task<PersonaDTO> EditPersona(string nombreCompleto, PersonaUpdateDTO updatePersona);

    }
}
