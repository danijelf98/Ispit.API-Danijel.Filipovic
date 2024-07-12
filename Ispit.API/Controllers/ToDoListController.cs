using Ispit.API.Model.Binding;
using Ispit.API.Model.Dbo;
using Ispit.API.Services.Implementation;
using Ispit.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
   
        private readonly IToDoListServices toDoListServices;

        public ToDoListController(ILogger<ToDoListController> logger)
        {
            this.toDoListServices = toDoListServices;
        }

        /// <summary>
        /// Gets a ToDoList by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ToDoList), StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> Get(int id)
        {

            var movie = await toDoListServices.GetToDoList(id);
            return Ok(movie);

        }

        /// <summary>
        /// Adds a ToDoList to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ToDoList), StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> Add([FromBody] ToDoListBinding model)
        {
            var ToDoList = await toDoListServices.AddToDoList(model);
            return Ok(ToDoList);
        }
        /// <summary>
        /// Deletes a ToDoList by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ToDoList), StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> Delete(int id)
        {
            await toDoListServices.DeleteToDoList(id);
            return Ok(new { Poruka = $"ToDoList sa idom {id} je uspješno obrisan!" });
        }
        /// <summary>
        /// Updates ToDoList
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoList(int id, ToDoListBinding model)
        {
            var updatedToDoList = await toDoListServices.UpdateToDoList(id, model);
            if (updatedToDoList == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
