using System.ComponentModel.DataAnnotations;

namespace Api.Request.Todo;

public class UpdateTodoRequest : Request
{
    [Required(ErrorMessage = "Nome da Tarefa Inválido")] //isso é data annotation
    [MaxLength(100, ErrorMessage = "Deve conter até 100 caracteres")]
    public string Tarefa { get; set; } = string.Empty;
    public bool Feito { get; set; } = false;
}

