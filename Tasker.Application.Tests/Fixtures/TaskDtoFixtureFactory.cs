using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tasker.Domain;

namespace Tasker.Application.Tests
{
    public static class TaskDtoFixtureFactory
    {
        public static TaskDto CreateTaskDto(Task task)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            return new TaskDto()
            {
                Id = task.Id,
                Description = task.Description,
                AddedDate = task.AddedDate
            };
        }

        public static IList<TaskDto> CreateTaskDtoListFromTaskList(IList<Task> taskList)
        {
            if (taskList == null)
                throw new ArgumentNullException("taskList");

            return CreateTaskDtoFromTaskListInternal(taskList);
        }

        public static IReadOnlyList<TaskDto> CreateReadOnlyTaskDtoListFromTaskList(IEnumerable<Task> taskList)
        {
            if (taskList == null)
                throw new ArgumentNullException("taskList");

            return CreateTaskDtoFromTaskListInternal(taskList).AsReadOnly();
        }

        private static List<TaskDto> CreateTaskDtoFromTaskListInternal(IEnumerable<Task> taskList)
        {
            if (taskList == null)
                throw new ArgumentNullException("taskList");

            var taskDtoList = new List<TaskDto>();

            foreach (var task in taskList)
                taskDtoList.Add(CreateTaskDto(task));

            return taskDtoList;
        }
    }
}
