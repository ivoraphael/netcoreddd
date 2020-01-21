using FluentValidation;
using netCoreAPI.Domain.DTOModels;
using netCoreAPI.Domain.Interfaces;
using netCoreAPI.Structure.Repositories;
using System;
using System.Collections.Generic;

namespace netCoreAPI.Service.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : BaseDTO
    {
        protected BaseRepository<TEntity> baseRepository = new BaseRepository<TEntity>();

        public TEntity Post<V>(TEntity model) where V : AbstractValidator<TEntity>
        {
            Validate(model, Activator.CreateInstance<V>());

            model = baseRepository.Insert(model);
            return model;
        }

        public IList<TEntity> GetAll()
        {
            IList<TEntity> listModel = baseRepository.GetAll();
            return listModel;
        }

        public TEntity GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public IList<TEntity> Get<V>(TEntity model) where V : AbstractValidator<TEntity>
        {
            Validate(model, Activator.CreateInstance<V>());

            IList<TEntity> listModel = baseRepository.Select(model);
            return listModel;
        }

        public TEntity Put<V>(TEntity model) where V : AbstractValidator<TEntity>
        {
            Validate(model, Activator.CreateInstance<V>());

            model = baseRepository.Update(model);
            return model;
        }

        public bool Delete(int id)
        {
            return baseRepository.Delete(id);
        }

        private void Validate(TEntity model, AbstractValidator<TEntity> validator)
        {
            if (model == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(model);
        }
    }
}
