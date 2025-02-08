using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.DTOs.Response
{
    public record GetAllResponse
    {
        public required int TotalRecords { get; init; }
        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalRecords / (PageSize == 0 ? 10 : PageSize));
            }
        }
        public required dynamic Items { get; init; }
        public required int CurrentPage { get; init; }
        public required int PageSize { get; init; }
        public required int PageNumber { get; init; }
        public required int page { get; init; }
        public int From
        {
            get
            {
                return (page - 1) * PageSize + 1;
            }
        }
        public int To
        {
            get
            {
                return Math.Min(page * PageSize, TotalRecords);
            }
        }
        public int LastPage
        {
            get
            {
                return totalPages;
            }
        }
        public int PerPage { get { return PageSize; } }
    }
}
