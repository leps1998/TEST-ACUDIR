using Acudir.Test.Apis.Domain;
using Acudir.Test.Apis.DTO;
using AutoMapper;

namespace Acudir.Test.Apis.Helper

{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Persona, PersonaDTO>();
            CreateMap<PersonaDTO, Persona>();

            CreateMap<PersonaAddDTO, Persona>();
            CreateMap<PersonaUpdateDTO, Persona>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

    }
}
