using System.Collections.Generic;

namespace Tasker.Application
{
    public class TaskListDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public IReadOnlyList<TaskDto> ListOfTasks { get; set; }
    }
}