using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.API.DTOs;
using ToDo.API.Respository;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(IToDoRepository repository, ILogger<ToDoController> logger)
        {
            _toDoRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.ToDo), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.ToDo>> AddAdOn([FromBody] Entities.ToDo toDo)
        {
           
            await _toDoRepository.AddAsync(toDo);

            return Ok(ResultDTO.Success("Todo save has been successfully"));
           
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDos()
        {
           var toDos = await _toDoRepository.GetAllAsync();

           return Ok(toDos);
        }
    }
}
