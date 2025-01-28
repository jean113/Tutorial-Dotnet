using api.Data;
using Api.Model;
using Api.Response;
using Api.Request.Todo;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers;

public class TodoHandler : ITodoHandler
{
    private readonly AppDbContext _context;

    public TodoHandler(AppDbContext context) { _context = context; }

    public async Task<Response<Todo?>> CreateAsync(CreateTodoRequest request)
    {
        try
        {
            var todo = new Todo
            {
                Tarefa = request.Tarefa,
            };

            await _context.Todo.AddAsync(todo);
            await _context.SaveChangesAsync();

            return new Response<Todo?>(todo, 201, "Todo criado com sucesso");
        }
        catch
        {
            return new Response<Todo?>(default(Todo?),500,"Não foi possível criar Todo");
        }
    }

    public async Task<Response<Todo?>> UpdateAsync(long id, UpdateTodoRequest request)
    {
        try
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(t => t.Id == id);

            if(todo is null)
                return new Response<Todo?>(default(Todo?),404,"Todo não encontrado");

            todo.Tarefa = request.Tarefa;
            todo.Feito = request.Feito;
        
            _context.Todo.Update(todo);
            await _context.SaveChangesAsync();

            return new Response<Todo?>(todo, 201, "Todo alterado com sucesso");
        }
        catch
        {
            return new Response<Todo?>(default(Todo?),500,"Não foi possível alterar o Todo");
        }
    }

    public async Task<Response<Todo?>> UpdateFeito(long id)
    {
        try
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(t => t.Id == id);

            if(todo is null)
                return new Response<Todo?>(default(Todo?),404,"Todo não encontrado");

            todo.Feito = !todo.Feito;
        
            _context.Todo.Update(todo);
            await _context.SaveChangesAsync();

            return new Response<Todo?>(todo, 201, "Todo marcado com sucesso");
        }
        catch
        {
            return new Response<Todo?>(default(Todo?),500,"Não foi possível marcar o Todo");
        }
    }

    public async Task<Response<Todo?>> DeleteAsync(long id)
    {
        try
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(t => t.Id == id);

            if(todo is null)
                return new Response<Todo?>(default(Todo?),404,"Todo não encontrado");

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();

            return new Response<Todo?>(todo, 201, "Todo alterado com sucesso");
        }
        catch
        {
            return new Response<Todo?>(default(Todo?),500,"Não foi possível alterar o Todo");
        }
    }

    public async Task<Response<Todo?>> GetByIdAsync(long id)
    {
        var todo = await _context.Todo.FirstOrDefaultAsync(todo => todo.Id == id);

        if (todo == null) {
            throw new Exception("Todo não encontrado!");
        }

        return new Response<Todo?>(todo);
      
    }

    public async Task<Response<List<Todo>>> GetAllAsync(GetAllTodosRequest request)
    {
        var todoPaged = await _context.Todo.OrderBy(p => p.Id).Skip((request.PageNumber - 1) * request.PageSize) .Take(request.PageSize).ToListAsync();
        
        return new Response<List<Todo>>(todoPaged);
    }
}
