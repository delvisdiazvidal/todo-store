using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ToDoListAddOrUpdDTO
    {
        [Required(ErrorMessage = "List Name is required")]
        [StringLength(20, ErrorMessage = "List Name can't be longer than 20 characters")]
        public string Name { get; set; }
    }
}