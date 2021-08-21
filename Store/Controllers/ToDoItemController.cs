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
    [Route("api/todo-items")]
    public class ToDoItemController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ToDoItemController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        // GET /api/todo-items
        [HttpGet]
        public IActionResult GetAllToDoItems()
        {
            try
            {
                var ToDoItems = _repository.ToDoItem.GetAllToDoItems();
                var ToDoItemsResult = _mapper.Map<IEnumerable<ToDoItemDTO>>(ToDoItems);
                return Ok(ToDoItemsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET /api​/todo-items​/{id}
        [HttpGet("{id}", Name = "byId")]
        public IActionResult GetToDoItemById(Guid id)
        {
            try
            {
                var ToDoItem = _repository.ToDoItem.GetToDoItemById(id);
                if (ToDoItem == null)
                {
                    return NotFound();
                }
                else
                {
                    var ToDoItemResult = _mapper.Map<ToDoItemDTO>(ToDoItem);
                    return Ok(ToDoItemResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside ToDoItemById action: {ex.Message}");

            }
        }


        // POST /api/todo-items
        [HttpPost]
        public IActionResult CreateToDoItem([FromBody] ToDoItemAddDTO toDoItem)
        {
            try
            {
                if (toDoItem == null)
                {
                    return BadRequest("Item object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if (_repository.ToDoList.GetToDoListById(toDoItem.ToDoListId) == null)
                {
                   return BadRequest("List object not Exist");
                }

                var itemEntity = _mapper.Map<ToDoItem>(toDoItem);

                _repository.ToDoItem.CreateToDoItem(itemEntity);
                _repository.Save();

                var createdToDoItem = _mapper.Map<ToDoItemDTO>(itemEntity);

                return CreatedAtRoute("byId", new { id = createdToDoItem.Id }, createdToDoItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside Create Item action: {ex.Message}");
            }
        }

        // PUT /api/todo-items/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateToDoItem(Guid id, [FromBody] ToDoItemUpdDTO toDoItem)
        {
            try
            {
                if (toDoItem == null)
                {
                    return BadRequest("Item object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var toDoItemEntity = _repository.ToDoItem.GetToDoItemById(id);
                if (toDoItemEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(toDoItem, toDoItemEntity);

                _repository.ToDoItem.UpdateToDoItem(toDoItemEntity);
                _repository.Save();

                return Ok(toDoItemEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside Update Item action: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                var toDoItemEntity = _repository.ToDoItem.GetToDoItemById(id);
                if (toDoItemEntity == null)
                {
                    return NotFound();
                }

                _repository.ToDoItem.DeleteToDoItem(toDoItemEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside Delete Item action: {ex.Message}");
            }
        }
      
    }
}