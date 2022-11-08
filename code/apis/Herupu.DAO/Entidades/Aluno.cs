using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Herupu.DAO.Entidades
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(100, ErrorMessage = "O nome do aluno deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome:")]
        [Column("NM_ALUNO")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data Nascimento obrigatória!")]
        [Display(Name = "Data Nascimento:")]
        [Column("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

    }
}
