using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;

namespace Store
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoList, ToDoListDTO>();
            CreateMap<ToDoListAddOrUpdDTO, ToDoList>();

            CreateMap<ToDoItem, ToDoItemDTO>();
            CreateMap<ToDoItemAddDTO, ToDoItem>();
            CreateMap<ToDoItemUpdDTO, ToDoItem>();

        }
    }
}
