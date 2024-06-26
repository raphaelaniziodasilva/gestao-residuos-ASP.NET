using gestao_residuos_ASP.NET.Models;

namespace gestao_residuos_ASP.NET.Dto
{
    public class ColetaAgendadaExibicaoDTO
    {
        public long Id { get; set; }
        public string DataColeta { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
        public ContatoExibicaoDto Contato { get; set; }
        public LixoExibicaoDTO Lixo { get; set; }

        public ColetaAgendadaExibicaoDTO() { }

        public ColetaAgendadaExibicaoDTO(ColetaAgendada coletaAgendada)
        {
            Id = coletaAgendada.Id;
            DataColeta = coletaAgendada.DataColeta.ToString("yyyy-MM-dd");
            Status = coletaAgendada.Status;
            Observacoes = coletaAgendada.Observacoes;
            Contato = new ContatoExibicaoDto
            {
                Id = coletaAgendada.Contato.Id,
                Nome = coletaAgendada.Contato.Nome,
                Email = coletaAgendada.Contato.Email,
                Telefone = coletaAgendada.Contato.Telefone,
                Rua = coletaAgendada.Contato.Rua,
                Cidade = coletaAgendada.Contato.Cidade,
                Cep = coletaAgendada.Contato.Cep
            };
            Lixo = new LixoExibicaoDTO
            {
                Id = coletaAgendada.Lixo.Id,
                Capacidade = coletaAgendada.Lixo.Capacidade,
                Localizacao = coletaAgendada.Lixo.Localizacao,
                Tipo = coletaAgendada.Lixo.Tipo,
                Descricao = coletaAgendada.Lixo.Descricao
            };
        }
    }
}
