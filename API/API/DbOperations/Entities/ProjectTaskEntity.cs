using API.DbOperations.Enums;
using System;

namespace API.DbOperations.Entities
{
    public class ProjectTaskEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
    }
}
