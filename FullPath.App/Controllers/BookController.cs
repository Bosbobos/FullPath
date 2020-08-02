using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullPath.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IClassRoomManager _entityManager;
        private readonly IValidator<ClassRoomCreateRequest> _validatorCreateRequest;

        public BookController(IClassRoomManager entityManager, IValidator<ClassRoomCreateRequest> validatorCreateRequest)
        {
            _entityManager = entityManager;
            _validatorCreateRequest = validatorCreateRequest;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<ClassRoomDto>> Get([FromQuery] Colors[] colors)
        {
            return await _entityManager.Get(colors);
        }

        [HttpPost, Consumes("application/json")]
        public async Task<ClassRoomDto> Create([FromBody] ClassRoomCreateRequest request)
        {
            await _validatorCreateRequest.ValidateAndThrowAsync(request);

            return await _entityManager.Create(request);
        }
    }
}
