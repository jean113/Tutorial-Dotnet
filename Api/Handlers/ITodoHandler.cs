using Api.Response;
using Api.Request.Todo;
using Api.Model;

namespace Api.Handlers;
public interface ITodoHandler //vantagem da interface é que ela pode ter múltiplas implementações
{
    Task<Response<Todo?>> CreateAsync(CreateTodoRequest request);
    Task<Response<Todo?>> UpdateAsync(long id, UpdateTodoRequest request);
    Task<Response<Todo?>> DeleteAsync(long id);
    Task<Response<Todo?>> GetByIdAsync(long id);
    Task<Response<List<Todo>>> GetAllAsync(GetAllTodosRequest request);
    Task<Response<Todo?>> UpdateFeito(long id);
}