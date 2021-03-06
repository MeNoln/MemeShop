﻿using System.Collections.Generic;

namespace DAL.Interfaces
{
    //Shop items Interface
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T model);
        void Edit(T model);
        void Delete(int id);
    }
}
