using System.Collections.Generic;
using AutoMapper;
using Task.Models.ViewModels;
using Task.Models;

namespace Task.Mappings
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<Todo, TodoVm>().ReverseMap();
            CreateMap<List<Todo>, List<TodoVm>>().ReverseMap();
        }        
    }
}