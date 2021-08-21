using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entities.Models
{
    [Table("ToDoList_Table")]
    public class ToDoList
    {
        [Column("ToDoListId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "List Name is required")]
        [StringLength(20, ErrorMessage = "List Name can't be longer than 20 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Date of Create List is required")]
        public DateTimeOffset CreateDate { get; set; }

        public ICollection<ToDoItem> ToDoItems { get; set; }
  }
}