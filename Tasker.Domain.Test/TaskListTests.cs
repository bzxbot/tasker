using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tasker.Domain.Test
{
    public static class TaskListTests
    {
        [Fact]
        public static void TaskListConstructorSuccessTest()
        {
            var taskListName = "Tasks";
            var taskList = new TaskList(taskListName);
            Assert.Equal(taskList.Description, taskListName);
            Assert.NotNull(taskList.ListOfTasks);
            Assert.Equal(taskList.ListOfTasks.Count, 0);
        }

        [Fact]
        public static void TaskListAddTaskSuccessTest()
        {
            var taskListName = "Tasks";
            var taskList = new TaskList(taskListName);
            var taskDescription = "Create unit tests for Tasker";
            taskList.AddTask(taskDescription);
            Assert.Equal(taskList.ListOfTasks.Count, 1);
            Assert.Equal(taskList.ListOfTasks[0].Description, taskDescription);
        }
    }
}
