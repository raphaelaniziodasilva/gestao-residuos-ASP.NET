using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gestao_residuos_ASP.NET.Models
{
    [Table("tbl_lixo")]
    public class Lixo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "A capacidade é obrigatória")]
        public double Capacidade { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho da localização não pode exceder 100 caracteres")]
        public string Localizacao { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho do tipo não pode exceder 50 caracteres")]
        public string Tipo { get; set; }

        [MaxLength(250, ErrorMessage = "O tamanho da descrição não pode exceder 250 caracteres")]
        public string Descricao { get; set; }

    }
}
