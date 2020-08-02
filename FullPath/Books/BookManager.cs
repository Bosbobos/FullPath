using System;
using System.Collections.Generic;
using System.Text;

namespace FullPath.Books
{
    class BookManager
    {
        private readonly ExampleFullPathContext _db;
        private readonly IMapper _mapper;

        public ClassRoomManager(ExampleFullPathContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ClassRoomDto> Create(ClassRoomCreateRequest request)
        {
            var entity = new ClassRoom()
            {
                Id = Guid.NewGuid(),
                ClassNum = request.ClassNum,
                Color = request.Color,
                Height = 10,
                Width = 20
            };

            _db.Add(entity); // добавить в отслеживаемость EF Core-у
            await _db.SaveChangesAsync(); // Сохранить все отслеживаемые объекты

            return _mapper.Map<ClassRoomDto>(entity);
        }

        public async Task<IReadOnlyCollection<ClassRoomDto>> Get(Colors[] colors)
        {
            var query = _db.ClassRooms // получить из таблицы записи (строчки) ClassRooms
                            .Include(o => o.ClassContent) // так же загрузить из отдельной таблицы записи ClassContent
                            .AsNoTracking(); // указание для оптимизации, чтобы EF Core не следил за изменениями

            if (colors != null && colors.Length > 0)
            {
                query = query.Where(o => colors.Contains(o.Color));
            }

            List<ClassRoom> entities = await query.ToListAsync();

            return entities
                    .Select(_mapper.Map<ClassRoomDto>)
                    .ToImmutableList();
        }
    }
}
