namespace Api.Model;

public class Todo
{
    public long  Id {get; set;}
    public string Tarefa {get; set;} = string.Empty;
	public  bool Feito {get; set;} 
    public DateTime DataCriacao {get; set;}

    public Todo(){}

    public Todo(string tarefa)
    {
        this.Tarefa = tarefa;
    }
}