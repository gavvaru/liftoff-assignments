using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp1.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
