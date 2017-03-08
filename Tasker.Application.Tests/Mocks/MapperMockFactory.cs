using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using Tasker.Domain;

namespace Tasker.Application.Tests
{
    public static class MapperMockFactory
    {
        public static IMapper CreateMapperWithTaskToTaskDtoMapping(Task task, TaskDto taskDto)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            if (taskDto == null)
                throw new ArgumentNullException("taskDto");

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<TaskDto>(task)).Returns(taskDto);
            return mapperMock.Object;
        }

        public static IMapper CreateMapperWithTaskToTaskDtoMapping(IList<Task> taskList, IList<TaskDto> taskDtoList)
        {
            if (taskList == null)
                throw new ArgumentNullException("taskList");

            if (taskDtoList == null)
                throw new ArgumentNullException("taskDtoList");

            var mapperMock = new Mock<IMapper>();

            foreach (var task in taskList)
                foreach(var taskDto in taskDtoList)
                    mapperMock.Setup(x => x.Map<TaskDto>(task)).Returns(taskDto);

            return mapperMock.Object;
        }


        public static IMapper CreateMapperWithTaskListToTaskListDtoMapping(TaskList task, TaskListDto taskDto)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            if (taskDto == null)
                throw new ArgumentNullException("taskDto");

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<TaskListDto>(task)).Returns(taskDto);
            return mapperMock.Object;
        }

        public static IMapper CreateMapperWithTaskListToTaskListDtoMapping(IList<TaskList> taskList, IList<TaskListDto> taskDtoList)
        {
            if (taskList == null)
                throw new ArgumentNullException("taskList");

            if (taskDtoList == null)
                throw new ArgumentNullException("taskDtoList");

            var mapperMock = new Mock<IMapper>();

            foreach (var task in taskList)
                foreach (var taskDto in taskDtoList)
                    mapperMock.Setup(x => x.Map<TaskListDto>(task)).Returns(taskDto);

            return mapperMock.Object;
        }
    }
}
