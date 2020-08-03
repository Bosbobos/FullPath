using System;
using System.Collections.Generic;
using System.Text;

namespace FullPath.Books
{
    class BookCreateRequest
    {
        public string Author { get; set; }
        public string Annotation { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Circulation { get; set; }
    }
}
