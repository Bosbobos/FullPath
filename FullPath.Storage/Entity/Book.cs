using System;
using System.Collections.Generic;
using System.Text;

namespace FullPath.Storage.Entity
{
    class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Annotation { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Circulation { get; set; }
        public Page[] Pages { get; set; }
    }
}
