using System.ComponentModel;

namespace LibrarySystem.Domain.DTOs.Request
{
    public class PaginationRequest
    {
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        public string? Word { get; set; }
    }
}
