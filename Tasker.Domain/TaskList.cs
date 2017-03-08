using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tasker.Domain
{
    public class TaskList
    {
        private List<Task> listOfTasks;

        public int Id { get; set; }

        public IReadOnlyList<Task> ListOfTasks
        {
            get
            {
                return listOfTasks.AsReadOnly();
            }
        }

        public string Description { get; private set; }

        public TaskList(string description)
        {
            listOfTasks = new List<Task>();
            Description = description;
        }

        public void AddTask(string description)
        {
            listOfTasks.Add(new Task(description));
        }
    }
}