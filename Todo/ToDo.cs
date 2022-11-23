namespace Todo
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
