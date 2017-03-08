using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Domain;

namespace Tasker.Application.Tests
{
    public static class TaskListFixtureFactory
    {
        public static TaskList CreateTaskList()
        {
            return new TaskList("List of tasks for Tasker") { Id = 1 };
        }

        public static IList<TaskList> CreateListWithTwoTaskLists()
        {
            return new List<TaskList>()
            {
                new TaskList("List of tasks for Tasker") { Id = 1 },
                new TaskList("List of groceries to buy") { Id = 2 }
            };
        }
    }
}
