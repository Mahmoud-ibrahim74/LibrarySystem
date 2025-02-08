using LibrarySystemAPI.DataAccess.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.DataAccess.Models.Books
{
    [Table("Borrowed_Book")]
    public class BorrowedBook
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
