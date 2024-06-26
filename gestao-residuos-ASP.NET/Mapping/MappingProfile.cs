using AutoMapper;
using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Models;

namespace gestao_residuos_ASP.NET.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContatoDto, Contato>();
            CreateMap<Contato, ContatoExibicaoDto>();

            CreateMap<LixoDTO, Lixo>();
            CreateMap<Lixo, LixoExibicaoDTO>();

            CreateMap<ColetaAgendadaDTO, ColetaAgendada>();
            CreateMap<ColetaAgendada, ColetaAgendadaExibicaoDTO>();
            
        }
    }
}
