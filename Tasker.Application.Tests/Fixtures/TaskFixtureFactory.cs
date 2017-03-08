using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasker.Domain;

namespace Tasker.Application.Tests
{
    public static class TaskFixtureFactory
    {
        public static Task CreateTask()
        {
            return new Task("Create unit tests for Tasker") { Id = 1 };
        }

        public static IList<Task> CreateListWithTwoTasks()
        {
            return new List<Task>()
            {
                new Task("Create unit tests for Tasker") { Id = 1 },
                new Task("Create integration tests for Tasker") { Id = 2 }
            };
        }
    }
}
