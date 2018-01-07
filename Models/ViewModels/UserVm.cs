using System;
using System.Collections.Generic;

namespace Task.Models.ViewModels
{
    public class UserVm
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public UserDetail Detail { get; set; }
        public List<Todo> Todos { get; set; }
    }
}