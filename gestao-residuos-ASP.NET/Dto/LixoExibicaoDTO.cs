using gestao_residuos_ASP.NET.Models;

namespace gestao_residuos_ASP.NET.Dto
{
    public class LixoExibicaoDTO
    {
        public long Id { get; set; }
        public double Capacidade { get; set; }
        public string Localizacao { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public LixoExibicaoDTO() { }

        public LixoExibicaoDTO(Lixo lixo)
        {
            Id = lixo.Id;
            Capacidade = lixo.Capacidade;
            Localizacao = lixo.Localizacao;
            Tipo = lixo.Tipo;
            Descricao = lixo.Descricao;
        }
    }
}
