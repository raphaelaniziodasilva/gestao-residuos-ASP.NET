using gestao_residuos_ASP.NET.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gestao_residuos_ASP.NET.Models
{
    [Table("tbl_coleta_agendada")]
    public class ColetaAgendada
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "A data de coleta é obrigatória")]
        [JsonPropertyName("dataColeta")]
        [JsonConverter(typeof(BrazilianDateConverter))]
        public DateTime DataColeta { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho do status não pode exceder 50 caracteres")]
        public string Status { get; set; }

        [MaxLength(250, ErrorMessage = "O tamanho das observações não pode exceder 250 caracteres")]
        public string Observacoes { get; set; }

        [Required]
        [ForeignKey("Contato")]
        public long ContatoId { get; set; }
        public Contato Contato { get; set; }

        [Required]
        [ForeignKey("Lixo")]
        public long LixoId { get; set; }
        public Lixo Lixo { get; set; }

    }
}
