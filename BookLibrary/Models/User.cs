using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class User : IdentityUser
    {



        [NotMapped]
        public string Password { get; set; }

        //Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
