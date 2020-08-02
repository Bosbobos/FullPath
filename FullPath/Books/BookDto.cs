using System;
using System.Collections.Generic;
using System.Text;

namespace FullPath.Books
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Annotation { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Circulation { get; set; }
        public Storage.Entity.Page[] Pages { get; set; }
    }
}
