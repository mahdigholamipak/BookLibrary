using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models.ViewModels
{
    public class BookViewModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Author { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }

        public string UserName { get; set; }
    }
}
