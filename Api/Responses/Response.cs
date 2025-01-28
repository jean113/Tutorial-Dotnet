using System.Text.Json.Serialization;

namespace Api.Response;

public class Response<T>
{
    private readonly int _code = 200;
    public T? Data { get; set; }
    public List<T?> ListData { get; set; }
    public string? Message { get; set; } = string.Empty;

    //o json pode não conseguir deserializar por isso um construtor com parametros vazio
    [JsonConstructor]
    public Response() => _code = 200;

    public Response(T? data,  int code = 200, string? message = null)
    {
        Data = data;
        Message = message;
        _code = code;
    }

    public Response(List<T?> data,  int code = 200, string? message = null)
    {
        ListData = data;
        Message = message;
        _code = code;
    }

    [JsonIgnore] //  precosp desse metodo publico, mas, o JsonIgnore vai impedir dele ser mostrado na response
    public bool IsSuccess => _code >= 200 && _code <= 299;
}