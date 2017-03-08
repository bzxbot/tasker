using System.Data.Entity.ModelConfiguration;
using Tasker.Domain;

namespace Tasker.Infrastructure.Persistence
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            ToTable("Tasks");
        }
    }
}
