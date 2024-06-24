using System.ComponentModel.DataAnnotations;

namespace gestao_residuos_ASP.NET.Dto
{
    public class LixoDTO
    {
        [Required(ErrorMessage = "A capacidade é obrigatória!")]
        [Range(0, double.MaxValue, ErrorMessage = "A capacidade deve ser maior ou igual a zero!")]
        public double Capacidade { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória!")]
        [MaxLength(300, ErrorMessage = "A localização deve conter no máximo 300 caracteres!")]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O tipo deve conter no máximo 100 caracteres!")]
        public string Tipo { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição deve conter no máximo 500 caracteres!")]
        public string Descricao { get; set; }
    }
}
