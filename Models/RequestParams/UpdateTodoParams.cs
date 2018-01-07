namespace Task.Models.RequestParams
{
    public class UpdateTodoParams
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
    }
}