using MediatR;
using Microsoft.AspNetCore.Mvc;
using Next.Steps.Application.Command;
using Next.Steps.Application.Dtos;
using Next.Steps.Application.Query;
using System.Collections.Generic;

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
        [Route("[Action]")]

        public ActionResult<IEnumerable<PersonReadDto>> GetAll()
        {
            var query = new PersonGetAllQuery();
            var response = _mediator.Send(query).Result;

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
        /// Get a Person by ID
        /// </summary>
        /// <param name="id">1</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<PersonReadDto> GetById(int id)
        {
            var query = new PersonGetByIdQuery
            {
                Id = id
            };

            var response = _mediator.Send(query).Result;

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
        /// <param name="p">Pessoa</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(PersonWriteDto p)
        {
            var command = new PersonCreateCommand
            {
                Person = p
            };

            var response = _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Update a Person
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Update(PersonUpdateDto p)
        {
            var command = new PersonUpdateCommand
            {
                Person = p
            };

            var status = _mediator.Send(command);

            return Ok(status);
        }

        /// <summary>
        /// Delete a Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var command = new PersonRemoveCommand
            {
                Id = id
            };

            var status = _mediator.Send(command).Result;

            if (status)
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
        /// <param name="firstName">Carlos</param>
        /// <param name="lastName">Ferreira</param>
        /// <returns></returns>
        [HttpGet("/search")]
        public ActionResult Search(string firstName, string lastName)
        {
            var query = new PersonSearchQuery
            {
                Firstname = firstName,
                Lastname = lastName
            };

            var response = _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
    }
}