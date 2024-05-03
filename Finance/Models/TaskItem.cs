namespace Finance.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }  // Assuming the User ID links to an authentication system
        public DateTime Date { get; set; }
        public string Tag { get; set; }
        public string CreatedBy { get; set; }
        public int ColumnId { get; set; }
        public virtual Column Column { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
