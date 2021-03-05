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
        /// Returns All Persons
        /// </summary>
        /// <returns>All Persons</returns>
        /// <response code="200">OK. Returns a list of all persons.</response>

        [HttpGet]
        [ProducesResponseType(200)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new PersonGetAllQuery();
            var response = await _mediator.Send(query);
            Log.Information("Get All executado com sucesso.");
            return Ok(response);
        }

        /// <summary>
        /// Returns a Person by Id
        /// </summary>
        /// <param name="id">The Id of one Person</param>
        /// <returns>Returns the attributes of a Person</returns>
        /// <remarks>
        /// Sample:
        ///
        ///     Get /Person/GetById/1
        ///
        /// </remarks>
        /// <response code="200">OK. Returns a Person by specified ID.</response>
        /// <response code="400">Bad request. Person ID must be an integer and bigger than 0.</response>
        /// <response code="404">Not Found. Person with the specified ID was not found.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /Person/Create
        ///
        /// </remarks>
        /// <response code="200">Person created.</response>
        [HttpPost]
        [ProducesResponseType(200)]
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
        /// Update a Person by specified ID
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /Person/Update/1
        ///
        /// </remarks>
        /// <response code="200">OK. Person Updated by specified ID.</response>
        /// <response code="400">Bad request. Person ID must be an integer and bigger than 0.</response>
        /// <response code="404">Not Found. Person with the specified ID was not found.</response>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        /// Delete a Person by specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /Person/Delete/1
        ///
        /// </remarks>
        /// <response code="200">OK. Person Deleted by specified ID.</response>
        /// <response code="400">Bad request. Person ID must be an integer and bigger than 0.</response>
        /// <response code="404">Not Found. Person with the specified ID was not found.</response>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        /// <param name="firstName">First name of the Person</param>
        /// <param name="lastName">Last name of the Person</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /Person/Search?firstname=teste&amp;lastname=teste2
        ///
        /// </remarks>
        /// <response code="200">OK. Person search sucess.</response>
        /// <response code="400">Bad request. Person ID must be an integer and bigger than 0.</response>
        /// <response code="404">Not Found. Person with the specified ID was not found.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("Search")]
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