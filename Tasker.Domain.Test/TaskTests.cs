using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tasker.Domain.Test
{
    public static class TaskTests
    {
        private const string taskDescription = "Testing Task";

        [Fact]
        public static void TaskConstructorSuccessTest()
        {
            var task = new Task(taskDescription);
            Assert.Equal(task.Description, taskDescription);
            Assert.True((DateTime.Now - task.AddedDate) < TimeSpan.FromSeconds(1));
            Assert.Null(task.CompletedDate);
            Assert.False(task.IsComplete);
        }

        [Fact]
        public static void TaskCompleteSuccessTest()
        {             
            var task = new Task(taskDescription);
            task.Complete();
            Assert.True(task.IsComplete);
            Assert.True((DateTime.Now - task.CompletedDate) < TimeSpan.FromSeconds(1));
        }
    }
}
