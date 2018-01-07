using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task.Models.RequestParams;

namespace Task.Models
{
    public class User
    {
        public string Id { get; set; }
        [MinLength(6)]
        public string Username { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public UserDetail Detail { get; set; }
        public List<Todo> Todos { get; set; }

        public User(NewUserParams newUser)
        {
            Username = newUser.Username;
            Password = newUser.Password;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
            Detail = new UserDetail();
            Todos = new List<Todo>();
        }
    }
}