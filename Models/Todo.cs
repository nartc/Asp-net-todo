using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Task.Models.RequestParams;

namespace Task.Models
{
    public class Todo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Content { get; set; }
        public string Slug { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public User User { get; set; }

        public Todo(NewTodoParams newTodo)
        {
            Title = newTodo.Title;
            Content = newTodo.Content;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
        }
    }
}