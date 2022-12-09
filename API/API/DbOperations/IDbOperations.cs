using API.DbOperations.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DbOperations
{
    public interface IDbOperations
    {
        public Task<List<ProjectTaskEntity>> GetAll();

        public Task<ProjectTaskEntity> AddTask(ProjectTaskEntity taskEntity);

        public Task DeleteTask(ProjectTaskEntity taskEntity);

        public Task<ProjectTaskEntity> UpdateTask(ProjectTaskEntity taskEntity);

    }
}
