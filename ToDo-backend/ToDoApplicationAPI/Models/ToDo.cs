namespace ToDoApplicationAPI.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
