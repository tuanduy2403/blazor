namespace Blazor.Modals
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public Comic? Commic { get; set; }
        public int ComicId { get; set; }
    }
}