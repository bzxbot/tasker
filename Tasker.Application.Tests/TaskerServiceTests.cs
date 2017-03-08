using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Tasker.Domain;
using Xunit;

namespace Tasker.Application.Tests
{
    public static class TaskerServiceTests
    {

        [Fact]
        public static void GetTaskFoundTest()
        {
            var task = TaskFixtureFactory.CreateTask();
            var taskDto = TaskDtoFixtureFactory.CreateTaskDto(task);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskToTaskDtoMapping(task, taskDto);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<Task>() { task });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            var taskFromService = taskerService.GetTask(1);
            Assert.Equal(task.AddedDate, taskFromService.AddedDate);
            Assert.Equal(task.Description, taskFromService.Description);
            Assert.Equal(task.Id, taskFromService.Id);
        }

        [Fact]
        public static void GetTaskNotFoundTest()
        {
            var task = TaskFixtureFactory.CreateTask();
            var taskDto = TaskDtoFixtureFactory.CreateTaskDto(task);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskToTaskDtoMapping(task, taskDto);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<Task>() { task });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            var taskFromService = taskerService.GetTask(2);
            Assert.Null(taskFromService);
        }

        [Fact]
        public static void GetAllTasksTaskFoundTest()
        {
            var taskList = TaskFixtureFactory.CreateListWithTwoTasks();
            var taskDtoList = TaskDtoFixtureFactory.CreateTaskDtoListFromTaskList(taskList);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskToTaskDtoMapping(taskList, taskDtoList);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(taskList);
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            var tasksFromService = taskerService.GetAllTasks();
            Assert.Equal(tasksFromService.Count, 2);
        }

        [Fact]
        public static void GetTaskListFoundTest()
        {
            var taskList = TaskFixtureFactory.CreateListWithTwoTasks();
            var taskDtoList = TaskDtoFixtureFactory.CreateTaskDtoListFromTaskList(taskList);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskToTaskDtoMapping(taskList, taskDtoList);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(taskList);
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            var tasksFromService = taskerService.GetAllTasks();
            Assert.Equal(tasksFromService.Count, 2);
        }

        [Fact]
        public static void GetAllTaskListsTest()
        {
            var listOfTaskList = TaskListFixtureFactory.CreateListWithTwoTaskLists();
            var listOftaskDto = TaskListDtoFixtureFactory.CreateTaskListDto(listOfTaskList);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskListToTaskListDtoMapping(listOfTaskList, listOftaskDto);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(listOfTaskList);
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            var tasksFromService = taskerService.GetAllTaskLists();
            Assert.Equal(tasksFromService.Count, 2);
        }

        [Fact]
        public static void GetTaskListNotFoundTest()
        {
            var taskList = TaskListFixtureFactory.CreateTaskList();
            var taskDtoList = TaskListDtoFixtureFactory.CreateTaskListDto(taskList);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskListToTaskListDtoMapping(taskList, taskDtoList);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<TaskList>() { taskList });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            var taskListFromService = taskerService.GetTaskList(1);
            Assert.Equal(taskListFromService.Id, taskList.Id);
            Assert.Equal(taskListFromService.Description, taskList.Description);
            Assert.Equal(taskListFromService.ListOfTasks.Count, taskList.ListOfTasks.Count);
        }

        [Fact]
        public static void AddTaskToEmptyListSuccessTest()
        {
            var description = "Create unit test to test AddTaskToList";
            var taskList = TaskListFixtureFactory.CreateTaskList();            
            var taskDtoList = TaskListDtoFixtureFactory.CreateTaskListDto(taskList);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskListToTaskListDtoMapping(taskList, taskDtoList);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<TaskList>() { taskList });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            taskerService.AddTaskToList(description, 1);
            Assert.Equal(taskList.ListOfTasks.Count, 1);
            Assert.Equal(taskList.ListOfTasks[0].Description, description);
            Assert.Equal(taskList.ListOfTasks[0].IsComplete, false);
            Assert.Null(taskList.ListOfTasks[0].CompletedDate);
            Assert.True((taskList.ListOfTasks[0].AddedDate - DateTime.Now) < TimeSpan.FromSeconds(1));
        }

        [Fact]
        public static void AddTaskToListWithOtherTasksSuccessTest()
        {
            var firstTaskDescription = "Create unit test to test AddTaskToList";
            var secondTaskDescription = "Create unit test to test AddTaskToList again";
            var taskList = TaskListFixtureFactory.CreateTaskList();
            var taskDtoList = TaskListDtoFixtureFactory.CreateTaskListDto(taskList);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskListToTaskListDtoMapping(taskList, taskDtoList);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<TaskList>() { taskList });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            taskerService.AddTaskToList(firstTaskDescription, 1);
            taskerService.AddTaskToList(secondTaskDescription, 1);
            Assert.Equal(taskList.ListOfTasks.Count, 2);
            Assert.Equal(taskList.ListOfTasks[1].Description, secondTaskDescription);
            Assert.Equal(taskList.ListOfTasks[1].IsComplete, false);
            Assert.Null(taskList.ListOfTasks[1].CompletedDate);
            Assert.True((taskList.ListOfTasks[1].AddedDate - DateTime.Now) < TimeSpan.FromSeconds(1));
        }

        [Fact]
        public static void AddTaskToListWithInvalidTaskListIdTest()
        {
            var description = "Create unit test to test AddTaskToList";
            var taskList = TaskListFixtureFactory.CreateTaskList();
            var taskDtoList = TaskListDtoFixtureFactory.CreateTaskListDto(taskList);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskListToTaskListDtoMapping(taskList, taskDtoList);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<TaskList>() { taskList });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            taskerService.AddTaskToList(description, 2);
            Assert.Equal(taskList.ListOfTasks.Count, 0);
        }

        [Fact]
        public static void AddTaskListSuccessTest()
        {
            var taskListDescription = "List of tasks for Tasker";
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<TaskList>());
            var mapperMock = new Mock<IMapper>();
            var taskerService = new TaskerService(taskerContextMock, mapperMock.Object);
            taskerService.AddTaskList(taskListDescription);
            var listOfTaskList = taskerService.GetAllTaskLists();
            Assert.Equal(listOfTaskList.Count, 1);
        }

        [Fact]
        public static void CompleteTaskSuccessTest()
        {
            var task = TaskFixtureFactory.CreateTask();
            var taskDto = TaskDtoFixtureFactory.CreateTaskDto(task);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskToTaskDtoMapping(task, taskDto);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<Task>() { task });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            taskerService.CompleteTask(1);
            Assert.True(task.IsComplete);
        }

        [Fact]
        public static void CompleteTaskNotFoundTest()
        {
            var task = TaskFixtureFactory.CreateTask();
            var taskDto = TaskDtoFixtureFactory.CreateTaskDto(task);
            var mapperMock = MapperMockFactory.CreateMapperWithTaskToTaskDtoMapping(task, taskDto);
            var taskerContextMock = TaskerContextMockFactory.CreateTaskerContextMock(new List<Task>() { task });
            var taskerService = new TaskerService(taskerContextMock, mapperMock);
            taskerService.CompleteTask(2);
        }
    }
}
