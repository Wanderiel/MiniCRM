namespace Domain.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public int CreatedById { get; set; }
        public int AssignedToId { get; set; }
        public DateOnly DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Sources { get; set; }
    }
}
