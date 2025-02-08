namespace LibrarySystem.Domain.DTOs.Response;

public class Response<T> where T : class
{
    public string Msg { get; set; } = string.Empty;
    public bool Check { get; set; }
    public T Data { get; set; } = default!;
    public string Error { get; set; } = string.Empty;
}


