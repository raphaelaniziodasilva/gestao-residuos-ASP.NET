using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gestao_residuos_ASP.NET.Dto
{
    public class ColetaAgendadaDTO
    {
        [Required(ErrorMessage = "A data da coleta é obrigatória!")]
        [JsonPropertyName("dataColeta")]
        public DateTime DataColeta { get; set; }

        [Required(ErrorMessage = "O status é obrigatório!")]
        public string Status { get; set; }

        [MaxLength(500, ErrorMessage = "As observações devem conter no máximo 500 caracteres!")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "O ID do contato é obrigatório!")]
        public long ContatoId { get; set; }

        [Required(ErrorMessage = "O ID do lixo é obrigatório!")]
        public long LixoId { get; set; }
    }
}
