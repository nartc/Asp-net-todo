using System;

namespace Task.Models.ViewModels
{
    public class TodoVm
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public User User { get; set; }
    }
}