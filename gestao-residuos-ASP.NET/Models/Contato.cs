using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gestao_residuos_ASP.NET.Models
{
    [Table("tbl_contato")]
    public class Contato
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho do nome não pode exceder 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho do e-mail não pode exceder 50 caracteres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "O tamanho do telefone não pode exceder 15 caracteres")]
        public string Telefone { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho da rua não pode exceder 100 caracteres")]
        public string Rua { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho da cidade não pode exceder 50 caracteres")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "O tamanho do estado não pode exceder 2 caracteres")]
        public string Estado { get; set; }

        [MaxLength(10, ErrorMessage = "O tamanho do CEP não pode exceder 10 caracteres")]
        public string Cep { get; set; }
    }
}
