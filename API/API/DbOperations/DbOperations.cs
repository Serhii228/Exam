using API.DbOperations.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DbOperations
{
    public class DbOperations: IDbOperations
    {
        public DbOperations()
        {

        }
        public async Task<List<ProjectTaskEntity>> GetAll()
        {
            using(var context = new EntityFrameworkCoreDbContext())
            {
                return context.Tasks.ToList();
            }
        }
        public Task<ProjectTaskEntity> AddTask(ProjectTaskEntity taskEntity)
        {
            using (var context = new EntityFrameworkCoreDbContext())
            {
                context.Tasks.Add(taskEntity);
                return Task.FromResult(taskEntity);
            }
        }
        public async Task DeleteTask(ProjectTaskEntity taskEntity)
        {
            using (var context = new EntityFrameworkCoreDbContext())
            {
                context.Tasks.Remove(taskEntity);
            }
        }
        public Task<ProjectTaskEntity> UpdateTask(ProjectTaskEntity taskEntity)
        {
            using (var context = new EntityFrameworkCoreDbContext())
            {
                context.Tasks.Remove(context.Tasks.First(x => x.Id == taskEntity.Id));
                context.Tasks.Add(taskEntity);
                return Task.FromResult(taskEntity);
            }
        }
    }
}
