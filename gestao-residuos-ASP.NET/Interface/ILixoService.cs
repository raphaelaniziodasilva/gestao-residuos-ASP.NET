using gestao_residuos_ASP.NET.Dto;
using gestao_residuos_ASP.NET.Models;
using System.Collections.Generic;


namespace gestao_residuos_ASP.NET.Interface
{
    public interface ILixoService
    {
        LixoExibicaoDTO SalvarLixo(LixoDTO lixoDto);
        List<Lixo> ListarLixos();
        LixoExibicaoDTO BuscarLixoPorId(long id);
        List<LixoExibicaoDTO> BuscarLixoPorTipo(string tipo);
        List<LixoExibicaoDTO> BuscarLixoPorLocalizacao(string localizacao);
        LixoExibicaoDTO Atualizar(long id, LixoDTO lixoDto);
        void Excluir(long id);
    }
}
