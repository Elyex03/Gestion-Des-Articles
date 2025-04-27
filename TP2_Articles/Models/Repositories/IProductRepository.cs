﻿using System.Collections.Generic;

namespace TP2_Articles.Models.Repositories
{
    public interface IProductRepository
    {
        Product GetById(int Id);
        IList<Product> GetAll();
        void Add(Product t);
        Product Update(Product t);
        void Delete(int Id);
        IList<Product> GetProductsByCategID(int? CategId);
        IList<Product> FindByName(string name);
        public IQueryable<Product> GetAllProducts();
    }
}