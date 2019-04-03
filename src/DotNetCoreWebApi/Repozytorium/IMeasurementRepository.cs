using DotNetCoreWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.Repozytorium
{
    interface IMeasurementRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(Measurement measurement, TEntity entity);
        Task Delete(Measurement measurement);
    }
}
