using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Herupu.DAO.Entidades
{
    public class Atividade
    {
        [Key]
        [Column("CD_ATIVIDADE")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAtividade { get; set; }

        [Required(ErrorMessage = "Nome da atividade obrigatória!")]
        [StringLength(100, ErrorMessage = "O nome da atividade deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome:")]
        [Column("NM_ATIVIDADE")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(500, ErrorMessage = "A descrição da atividade deve ter no máximo 500 caracteres")]
        [Display(Name = "Descrição:")]
        [Column("DESCR_ATIVIDADE")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Instrução obrigatória!")]
        [StringLength(500, ErrorMessage = "A instrução da atividade deve ter no máximo 500 caracteres")]
        [Display(Name = "Instrução para realizar:")]
        [Column("INSTRUCAO_ATIVIDADE")]
        public string Instrucao { get; set; }

        [Column("IDADE_SUG_ATIVIDADE")]
        public int IdadeSugerida { get; set; }

        //[JsonIgnore]
        //[NotMapped]
        //public IList<AtividadeItem> AtividadeItens { get; set; }
    }
}