using System.Data.Entity;
using Tasker.Domain;

namespace Tasker.Infrastructure.Persistence
{
    // Unfortunately, using this couples the application layer with the persistence layer, which is created
    // using Entity Framework. It's a not 100% independent Onion architecture. The object model is not truly
    // independent from outside dependencies. This happens because it's a lot of trouble to implement an
    // agnostic persistence model. To do it, we need to manually create the structures for persistence, probably
    // creating a Unit of Work class and Repositories, and their respective implementations using Entity Framework.
    public interface ITaskerContext
    {
        IDbSet<Task> Tasks { get; set; }

        IDbSet<TaskList> TaskLists { get; set; }

        int SaveChanges();
    }
}
