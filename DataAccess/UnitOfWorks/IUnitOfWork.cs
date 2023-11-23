﻿using Core.Entities;
using DataAccess.Repositories.Abstract;

namespace DataAccess.UnitOfWorks;
public interface IUnitOfWork:IAsyncDisposable
{
    IEntityRepository<T> GetRepository<T>() where T : class,IEntityBase,new();
    Task<int> SaveAsync();
    int Save();
}
