﻿using RedisExampleBaris.API.Models;

namespace RedisExampleBaris.API.Services
{
    public interface IProductService
    {

        Task<List<Product>> GetAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);
    }
}
