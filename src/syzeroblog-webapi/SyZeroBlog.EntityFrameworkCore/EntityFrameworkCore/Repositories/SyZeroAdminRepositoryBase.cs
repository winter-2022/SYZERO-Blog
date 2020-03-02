using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;
using SyZero.EntityFrameworkCore.Repositories;
using SyZeroBlog.EntityFrameworkCore;

namespace SyZeroBlog.EntityFrameworkCore.Repositories
{
    public  class SyZeroBlogRepositoryBase<TEntity> : EfRepository<SyZeroBlogDbContext,TEntity>
      where TEntity : class, IEntity
    {
        public SyZeroBlogRepositoryBase(SyZeroBlogDbContext dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

}
