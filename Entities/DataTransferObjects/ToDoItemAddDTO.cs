using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ToDoItemAddDTO
    {
        [Required(ErrorMessage = "Item Name is required")]
        [StringLength(20, ErrorMessage = "Item Name can't be longer than 20 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Item Description is required")]
        [StringLength(100, ErrorMessage = "Item Description can't be longer than 100 characters")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Item status is required")]
        [EnumDataType((typeof(ToDoItemStatus)), ErrorMessage = "The statuses of the Item allowed are: PENDING, COMPLETE")]
        public string Status { get; set; }

        public Guid ToDoListId { get; set; }
    }
}