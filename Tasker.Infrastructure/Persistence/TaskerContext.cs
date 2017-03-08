using System;
using System.Data.Entity;
using Tasker.Domain;

namespace Tasker.Infrastructure.Persistence
{
    public class TaskerContext : DbContext, ITaskerContext
    {
        public IDbSet<Task> Tasks { get; set; }

        public IDbSet<TaskList> TaskLists { get; set; }

        public TaskerContext()
            : base("TaskerContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new TaskListConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        int ITaskerContext.SaveChanges()
        {
            return SaveChanges();
        }
    }
}
