using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Contracts
{
    public interface IProductsService
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> GetById(int id);

        Task<Product> UpdateProduct(int id, Product p);

        Task DeleteProduct(int id);

        Task<Product> AddNewProduct(Product p);
    }
}
