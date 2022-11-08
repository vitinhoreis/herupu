using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Herupu.DAO.Entidades
{
    public class HistoricoAluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistoricoAluno { get; set; }

        [Required(ErrorMessage = "Id da Atividade obrigatória!")]
        [Display(Name = "Id Item Atividade:")]
        public int IdItemAtividade { get; set; }

        [Required(ErrorMessage = "Informe se o aluno acertou")]
        [Display(Name = "Acertou?:")]
        [Column("ACERTOU")]
        public bool Acertou { get; set; }

        [Display(Name = "Acertou?:")]
         public DateTime DataHoraRealizacao { get; set; }

        [Required(ErrorMessage = "Id do Aluno obrigatório!")]
        [Display(Name = "Id do Aluno:")]
        public int IdAluno { get; set; }
    }
}
