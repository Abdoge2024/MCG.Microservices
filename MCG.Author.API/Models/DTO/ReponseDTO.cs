namespace MCG.Author.API.Models.DTO
{
    public class ReponseDTO
    {
        public object? Results { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
