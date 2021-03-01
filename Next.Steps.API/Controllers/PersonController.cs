using MediatR;
using Microsoft.AspNetCore.Mvc;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dtos;
using Next.Steps.Application.Query;
using Serilog;
using System.Threading.Tasks;

namespace Next.Steps.API.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new PersonGetAllQuery();
            var response = await _mediator.Send(query);
            Log.Information("Get All executado com sucesso.");
            return Ok(response);
        }

        /// <summary>
        /// Get a Person by ID
        /// </summary>
        /// <param name="id">1</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                Log.Error("Id invalido: " + id);
                return BadRequest();
            }
            var query = new PersonGetByIdQuery
            {
                Id = id
            };

            var response = await _mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        /// <summary>
        /// Create a Person
        /// </summary>
        /// <param name="p">Person</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(PersonWriteDto p)
        {
            if (p != null)
            {
                var command = new PersonCreateCommand
                {
                    Person = p
                };
                await _mediator.Send(command);
                Log.Information("Criado com sucesso.");
            }
            Log.Error("Erro: sem objecto");
            return NoContent();
        }

        /// <summary>
        /// Update a Person
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync(PersonUpdateDto obj)
        {
            if (obj != null)
            {
                var command = new PersonUpdateCommand
                {
                    Person = obj
                };
                Log.Information("Update realizado com sucesso.");
                await _mediator.Send(command);
            }
            Log.Error("Erro: sem objecto");
            return NoContent();
        }

        /// <summary>
        /// Delete a Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            if (id <= 0)
            {
                Log.Error("Id invalido: " + id);
                return BadRequest();
            }
            var command = new PersonRemoveCommand
            {
                Id = id
            };

            var result = await _mediator.Send(command);
            Log.Information("Removido com sucesso.");
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Search a Person by First Name or Last Name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet("/Search")]
        public async Task<IActionResult> SearchAsync(string firstName, string lastName)
        {
            var query = new PersonSearchQuery
            {
                Firstname = firstName,
                Lastname = lastName
            };

            var response = await _mediator.Send(query);
            Log.Information("Comando executado com sucesso.");
            return Ok(response);
        }
    }
}