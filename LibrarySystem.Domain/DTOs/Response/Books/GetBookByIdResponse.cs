namespace LibrarySystem.Domain.DTOs.Response.Books
{
    public record GetBookByIdResponse
    {
        public string Title { get; init; }
        public string Author { get; init; }
        public string Genre { get; init; }
        public int PublishedYear { get; init; }
        public bool IsAvailable { get; init; }
    }
}
