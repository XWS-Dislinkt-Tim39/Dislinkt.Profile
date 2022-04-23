﻿using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Persistance.MongoDB.Common
{
    public interface IQueryExecutor
    {
        Task<T> FindByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<IReadOnlyCollection<T>> FindAsync<T>(FilterDefinition<T> filterDefinition) where T : BaseEntity;
        Task CreateAsync<T>(T t) where T : BaseEntity;
        Task DeleteByIdAsync<T>(FilterDefinition<T> filterDefinition) where T : BaseEntity;
        Task UpdateAsync<T>(FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition) where T : BaseEntity;
        Task<IReadOnlyCollection<T>> GetAll<T>() where T : BaseEntity;
    }
}
