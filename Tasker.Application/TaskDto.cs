using System;

namespace Tasker.Application
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? CompletedDate { get; set; }
    }
}