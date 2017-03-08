using System;

namespace Tasker.Domain
{
    public class Task
    {
        public int Id { get; set; }

        public string Description { get; private set; }

        public bool IsComplete { get; private set; }

        public DateTime AddedDate { get; private set; }

        public DateTime? CompletedDate { get; private set; }

        public Task(string description)
        {
            Description = description;
            AddedDate = DateTime.Now;
        }

        public void Complete()
        {
            IsComplete = true;
            CompletedDate = DateTime.Now;
        }
    }
}
