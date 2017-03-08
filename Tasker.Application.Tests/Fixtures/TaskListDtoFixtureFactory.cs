using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasker.Domain;

namespace Tasker.Application.Tests
{
    public static class TaskListDtoFixtureFactory
    {
        public static TaskListDto CreateTaskListDto(TaskList taskList)
        {
            if (taskList == null)
                throw new ArgumentNullException("taskList");

            return new TaskListDto()
            {
                Id = taskList.Id,
                Description = taskList.Description,
                ListOfTasks = TaskDtoFixtureFactory.CreateReadOnlyTaskDtoListFromTaskList(taskList.ListOfTasks)
            };
        }

        public static IList<TaskListDto> CreateTaskListDto(IList<TaskList> listOfTaskLists)
        {
            if (listOfTaskLists == null)
                throw new ArgumentNullException("listOfTaskLists");

            var listOfTaskListDto = new List<TaskListDto>();

            foreach (var taskList in listOfTaskLists)
                listOfTaskListDto.Add(CreateTaskListDto(taskList));

            return listOfTaskListDto;
        }
    }
}
