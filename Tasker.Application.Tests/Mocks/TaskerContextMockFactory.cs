using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tasker.Domain;
using Tasker.Infrastructure.Persistence;

namespace Tasker.Application.Tests
{
    public static class TaskerContextMockFactory
    {
        public static ITaskerContext CreateTaskerContextMock(IList<Task> taskList)
        {
            var tasksQueryable = taskList.AsQueryable();
            var tasksDbSetMock = new Mock<IDbSet<Task>>();
            var taskerContextMock = new Mock<ITaskerContext>();
            tasksDbSetMock.Setup(m => m.Provider).Returns(tasksQueryable.Provider);
            tasksDbSetMock.Setup(m => m.Expression).Returns(tasksQueryable.Expression);
            tasksDbSetMock.Setup(m => m.ElementType).Returns(tasksQueryable.ElementType);
            tasksDbSetMock.Setup(m => m.GetEnumerator()).Returns(tasksQueryable.GetEnumerator());
            taskerContextMock.Setup(m => m.Tasks).Returns(tasksDbSetMock.Object);
            return taskerContextMock.Object;
        }

        public static ITaskerContext CreateTaskerContextMock(IList<TaskList> taskList)
        {
            var tasksQueryable = taskList.AsQueryable();
            var tasksDbSetMock = new Mock<IDbSet<TaskList>>();
            var taskerContextMock = new Mock<ITaskerContext>();
            tasksDbSetMock.Setup(m => m.Provider).Returns(tasksQueryable.Provider);
            tasksDbSetMock.Setup(m => m.Expression).Returns(tasksQueryable.Expression);
            tasksDbSetMock.Setup(m => m.ElementType).Returns(tasksQueryable.ElementType);
            tasksDbSetMock.Setup(m => m.GetEnumerator()).Returns(tasksQueryable.GetEnumerator());
            tasksDbSetMock.Setup(m => m.Add(It.IsAny<TaskList>())).Callback<TaskList>((element) => taskList.Add(element));
            taskerContextMock.Setup(m => m.TaskLists).Returns(tasksDbSetMock.Object);
            return taskerContextMock.Object;
        }
    }
}
