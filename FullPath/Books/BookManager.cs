using AutoMapper;
using FullPath.Storage;
using FullPath.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPath.Books
{
    class BookManager
    {
        private readonly FullPathContext _db;
        private readonly IMapper _mapper;

        public BookManager(FullPathContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BookDto> Create(BookCreateRequest request)
        {
            var entity = new Book()
            {
                Id = Guid.NewGuid(),
                Author = request.Author,
                Annotation = request.Annotation,
                CreatedAt = request.CreatedAt,
                Circulation = request.Circulation
            };

            _db.Add(entity); // добавить в отслеживаемость EF Core-у
            await _db.SaveChangesAsync(); // Сохранить все отслеживаемые объекты

            return _mapper.Map<BookDto>(entity);
        }

        public async Task<IReadOnlyCollection<BookDto>> Get(Page[] pages)
        {
            var query = _db.Books // получить из таблицы записи (строчки) Books
                            .AsNoTracking(); // указание для оптимизации, чтобы EF Core не следил за изменениями

            if (pages != null && pages.Length > 0)
            {
                query = query.Where(o => pages.Contains(o.Page));
            }

            List<Book> entities = await query.ToListAsync();

            return entities
                    .Select(_mapper.Map<BookDto>)
                    .ToImmutableList();
        }
    }
}
