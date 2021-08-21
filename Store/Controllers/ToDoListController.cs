using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/todo-lists")]
    public class ToDoListController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ToDoListController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAllToDoLists()
        {
            try
            {
                var ToDoLists = _repository.ToDoList.GetAllToDoLists();
                var ToDoListsResult = _mapper.Map<IEnumerable<ToDoListDTO>>(ToDoLists);
                return Ok(ToDoListsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}", Name = "ToDoListById")]
        public IActionResult GetToDoListById(Guid id)
        {
            try
            {
                var ToDoList = _repository.ToDoList.GetToDoList(id);
                if (ToDoList == null)
                {
                    return NotFound();
                }
                else
                {
                    var ToDoListResult = _mapper.Map<ToDoListDTO>(ToDoList);
                    return Ok(ToDoListResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside ToDoListById action: {ex.Message}");

            }
        }


        [HttpPost]
        public IActionResult CreateToDoList([FromBody] ToDoListAddOrUpdDTO toDoList)
        {
            try
            {
                if (toDoList == null)
                {
                    return BadRequest("Order object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                
                var listEntity = _mapper.Map<ToDoList>(toDoList);

                _repository.ToDoList.CreateToDoList(listEntity);
                _repository.Save();

                var createdList = _mapper.Map<ToDoListDTO>(listEntity);

                return CreatedAtRoute("ToDoListById", new { id = createdList.Id }, createdList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside Create List action: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateToDoList(Guid id, [FromBody] ToDoListAddOrUpdDTO toDoList)
        {
            try
            {
                if (toDoList == null)
                {
                    return BadRequest("List object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var listEntity = _repository.ToDoList.GetToDoListById(id);
                if (listEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(toDoList, listEntity);

                _repository.ToDoList.UpdateToDoList(listEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside Update List action: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(Guid id)
        {
            try
            {
                var toDoList = _repository.ToDoList.GetToDoListById(id);
                if (toDoList == null)
                {
                    return NotFound();
                }

                if (_repository.ToDoItem.ToDoItemsByList(id).Any())
                {
                    _repository.ToDoItem.DeleteToDoItemByList(id);
                }

                _repository.ToDoList.DeleteToDoList(toDoList);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside Delete List action: {ex.Message}");
            }
        }

    }
}