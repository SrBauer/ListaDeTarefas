using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Preencha a Descrição.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha a Data de Vencimento.")]
        public DateTime? DataDeVencimento { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria!")]
        public string CategoriaId { get; set; }

        [ValidateNever]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Selecione uma Categoria")]
        public string StatusId { get; set; }

        [ValidateNever]
        public Status Status { get; set; }

        public bool Atrasado => StatusId == "aberto" && DataDeVencimento < DateTime.Today;
    }
}
