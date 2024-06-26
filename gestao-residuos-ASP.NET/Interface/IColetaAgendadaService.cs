using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Models;

namespace gestao_residuos_ASP.NET.Interface
{
    public interface IColetaAgendadaService
    {
        ColetaAgendadaExibicaoDTO SalvarColetaAgendada(ColetaAgendadaDTO coletaAgendadaDto);
        List<ColetaAgendadaExibicaoDTO> ListarColetasAgendadas();
        ColetaAgendadaExibicaoDTO BuscarColetaAgendadaPorId(long id);
        List<ColetaAgendadaExibicaoDTO> BuscarColetasPorData(string dataColeta);
        List<ColetaAgendadaExibicaoDTO> BuscarColetasPorStatus(string status);
        ColetaAgendada Atualizar(long id, ColetaAgendadaDTO coletaAgendadaDto);
        void Excluir(long id);
        long ContarColetasPorContato(long contatoId);
    }
}
