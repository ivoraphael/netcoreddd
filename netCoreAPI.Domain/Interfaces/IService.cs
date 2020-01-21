using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreAPI.Domain.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Post<V>(TEntity model) where V : AbstractValidator<TEntity>;

        IList<TEntity> GetAll();

        TEntity GetById(int id);

        IList<TEntity> Get<V>(TEntity model) where V : AbstractValidator<TEntity>;

        TEntity Put<V>(TEntity model) where V : AbstractValidator<TEntity>;

        bool Delete(int id);
    }
}
