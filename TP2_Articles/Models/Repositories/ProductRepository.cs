﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TP2_Articles.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IList<Product> GetAll()
        {
            return context.Products
                .OrderBy(x => x.Name)
                .Include(x => x.Category).ToList();
        }

        public Product GetById(int id)
        {
            return context.Products
                .Where(x => x.ProductId == id)
                .Include(x => x.Category)
                .SingleOrDefault();
        }

        public void Add(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        public Product Update(Product p)
        {
            Product p1 = context.Products.Find(p.ProductId);
            if (p1 != null)
            {
                p1.Name = p.Name;
                p1.Price = p.Price;
                p1.QteStock = p.QteStock;
                p1.CategoryId = p.CategoryId;
                p1.Image = p.Image;
                context.SaveChanges();
            }
            return p1;
        }

        public void Delete(int ProductId)
        {
            Product p1 = context.Products.Find(ProductId);
            if (p1 != null)
            {
                context.Products.Remove(p1);
                context.SaveChanges();
            }
        }

        public IList<Product> GetProductsByCategID(int? CategId)
        {
            return context.Products
                .Where(p => p.CategoryId.Equals(CategId))
                .OrderBy(p => p.ProductId)
                .Include(p => p.Category).ToList();
        }

        public IList<Product> FindByName(string name)
        {
            return context.Products
                .Where(p => p.Name.Contains(name) ||
                       p.Category.CategoryName.Contains(name))
                .Include(c => c.Category).ToList();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return context.Products.Include(p => p.Category);
        }
    }
}