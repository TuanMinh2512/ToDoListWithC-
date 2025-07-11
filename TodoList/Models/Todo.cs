namespace TodoList.Models
{
    public class Todo
    {
        public int id { get; set; }
        public required string text { get; set; }
        public bool isCompleted { get; set; }
    }
}
