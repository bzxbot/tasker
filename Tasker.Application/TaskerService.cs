using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Tasker.Domain;
using Tasker.Infrastructure.Persistence;

namespace Tasker.Application
{
    public class TaskerService
    {
        private ITaskerContext taskerContext;
        private IMapper mapper;

        public TaskerService(ITaskerContext taskerContext, IMapper mapper)
        {
            this.taskerContext = taskerContext;
            this.mapper = mapper;
        }

        public TaskDto GetTask(int taskId)
        {
            var taskQuery = from t in taskerContext.Tasks
                            where t.Id == taskId
                            select mapper.Map<TaskDto>(t);

            return taskQuery.FirstOrDefault();
        }

        // Code Analysis suggests to turn this into a property.
        // It wouldn't conform to the architecture style chosen for the application.
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IList<TaskDto> GetAllTasks()
        {
            var allTasksQuery = from task in taskerContext.Tasks
                                select mapper.Map<TaskDto>(task);

            return allTasksQuery.ToList();
        }

        public TaskListDto GetTaskList(int taskListId)
        {
            var taskListQuery = from taskList in taskerContext.TaskLists
                                where taskList.Id == taskListId
                                select mapper.Map<TaskListDto>(taskList);

            return taskListQuery.FirstOrDefault();
        }

        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IList<TaskListDto> GetAllTaskLists()
        {
            var taskListQuery = from taskList in taskerContext.TaskLists
                                select mapper.Map<TaskListDto>(taskList);

            return taskListQuery.ToList();
        }

        public void AddTaskToList(string description, int taskListId)
        {
            var taskListQuery = from t in taskerContext.TaskLists
                                where t.Id == taskListId
                                select t;

            var taskList = taskListQuery.FirstOrDefault();

            taskList?.AddTask(description);

            taskerContext.SaveChanges();
        }

        public void AddTaskList(string description)
        {
            var taskList = new TaskList(description);

            taskerContext.TaskLists.Add(taskList);

            taskerContext.SaveChanges();
        }

        public void CompleteTask(int taskId)
        {
            var taskQuery = from t in taskerContext.Tasks
                            where t.Id == taskId
                            select t;

            var task = taskQuery.FirstOrDefault();

            task?.Complete();

            taskerContext.SaveChanges();
        }
    }
}
