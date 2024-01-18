namespace Models.DTOs;

public class DefaultResponse<TType>
{
    public bool Success { get; set; }

    public TType Data { get; set; }

    public string Message { get; set; }

    public List<string> Errors { get; set; }
}
