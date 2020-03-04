﻿using FluentValidation;
using Seed.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seed.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {

        private BaseRepository<T> repository = new BaseRepository<T>();
        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Remove(id);
        }

       

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.Select(id);
        }

        public IList<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
