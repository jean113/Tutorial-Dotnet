using Microsoft.AspNetCore.Mvc;
using api.Data;
using Api.Handlers;
using Api.Model;
using Api.Request.Todo;
using Api.Response;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ITodoHandler _todoHandler;
    public TodoController(AppDbContext context, ITodoHandler todoHandler) 
    {
        _context = context;
        _todoHandler = todoHandler;
    }

    /*As informações vão aparecer no swagger. Utilizado para documentação*/
         /// <summary>
    /// Cria um Todo
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "nome": "Martin Scorsese"
    ///     }
    ///
    /// </remarks>
    /// <param name="createTodoRequest">Nome do Todo</param>
    /// <returns>O todo criado</returns>
    /// <response code="200">todo foi criado com sucesso</response>
    /// <response code="500">Erro inesperado</response>
    /// <response code="400">Erro validação</response>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateTodoRequest createTodoRequest)
    {
        await _todoHandler.CreateAsync(createTodoRequest);
        
        return Ok("Todo inserido");
    } 

//     /*As informações vão aparecer no swagger. Utilizado para documentação*/
//          /// <summary>
//     /// Retorna todos os todos cadastrados
//     /// </summary>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /Todo
//     /// </remarks>
//     /// <returns>Retorna uma lista de todos</returns>
//     /// <response code="200">Todos os todos encontrados</response>
//     /// <response code="500">Erro inesperado</response>
//     /// <response code="400">Nenhume todo encontrado</response>
    [HttpGet] //retorna todos os itens
    public async Task<ActionResult<Response<List<Todo>>>> GetAllAsync([FromQuery]GetAllTodosRequest getAllTodosRequest) 
    {
        var retorno = await _todoHandler.GetAllAsync(getAllTodosRequest);
        return Ok(retorno);
    } 


    
//       /*As informações vão aparecer no swagger. Utilizado para documentação*/
//          /// <summary>
//     /// Retorna um todo especifico
//     /// </summary>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     GET /todo/{id}
//     ///     {
//     ///        "id": "1"
//     ///     }
//     ///
//     /// </remarks>
//     /// <param name="id">Id do todo</param>
//     /// <returns>O todo recuperado de acordo com o id</returns>
//     /// <response code="200">todo encontrado</response>
//     /// <response code="500">Erro inesperado</response>
//     /// <response code="400">Erro validação</response>
    [HttpGet("{id}")] //retorna mais especifico
    public async Task<ActionResult<Todo>> Get(int id)
    {
  
           var todo = await _todoHandler.GetByIdAsync(id);

           return Ok(todo);
    
    } 


//       /*As informações vão aparecer no swagger. Utilizado para documentação*/
//          /// <summary>
//     /// Altera dados do Todo
//     /// </summary>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     PUT /Todo/{id}
//     ///     {
//     ///       "id": "1",
//     ///        "nome": "Martin Scorsese"
//     ///     }
//     ///
//     /// </remarks>
    /// <param name="updateTodoRequest">todo</param>
    /// <returns>O todo alterado</returns>
    /// <response code="200">todo foi alterado com sucesso</response>
    /// <response code="500">Erro inesperado</response>
    /// <response code="400">Erro validação</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<Todo>> Put(long id, [FromBody] UpdateTodoRequest updateTodoRequest)
    {
        await _todoHandler.UpdateAsync(id, updateTodoRequest);

        return Ok("Todo Alterado");

    } 

    [HttpPut("marcar-todo/{id}")]
    public async Task<ActionResult<Todo>> MarcarTodo(long id)
    {
        await _todoHandler.UpdateFeito(id);

        return Ok("Todo Alterado");

    } 

//       /*As informações vão aparecer no swagger. Utilizado para documentação*/
//          /// <summary>
//     /// Delete um Todo
//     /// </summary>
//     /// <remarks>
//     /// Sample request:
//     ///
//     ///     DELETE /Todo/{id}
//     ///     {
//     ///    
//     ///     }
//     ///
//     /// </remarks>
    /// <param name="id">Id do Todo a ser alterado</param>
    /// <returns>não retorna nada</returns>
    /// <response code="200">Todo foi deletado com sucesso</response>
    /// <response code="500">Erro inesperado</response>
    /// <response code="400">Erro validação</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _todoHandler.DeleteAsync(id);

        return Ok("Todo Deletado");
    } 
}