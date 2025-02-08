namespace LibrarySystem.Domain.DTOs.Request.Books
{
    public class CreateUpdateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }
    }
}
