using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Task.Models.RequestParams;

namespace Task.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
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