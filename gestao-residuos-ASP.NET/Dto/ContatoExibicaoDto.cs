using gestao_residuos_ASP.NET.Models;

namespace gestao_residuos_ASP.NET.Dto
{
    public class ContatoExibicaoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public ContatoExibicaoDto() { }

        public ContatoExibicaoDto(Contato contato)
        {
            Id = contato.Id;
            Nome = contato.Nome;
            Email = contato.Email;
            Telefone = contato.Telefone;
            Rua = contato.Rua;
            Cidade = contato.Cidade;
            Estado = contato.Estado;
            Cep = contato.Cep;
        }
    }
}
