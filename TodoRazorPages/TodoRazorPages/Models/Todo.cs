using System.ComponentModel.DataAnnotations;

namespace TodoRazorPages.Models
{
    public enum EstadoTarefa { Do, Doing, Done }

    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        public string? Nome { get; set; }
        [MaxLength(20, ErrorMessage = "A descrição da tarefa é obrigatória.")]
        public string? Descricao { get; set; }
        public EstadoTarefa EstadoTarefa { get; set; } = EstadoTarefa.Do;

    }
}
