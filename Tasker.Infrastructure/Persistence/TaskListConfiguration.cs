using System.Data.Entity.ModelConfiguration;
using Tasker.Domain;

namespace Tasker.Infrastructure.Persistence
{
    public class TaskListConfiguration : EntityTypeConfiguration<TaskList>
    {
        public TaskListConfiguration()
        {
            ToTable("TaskLists");
        }
    }
}