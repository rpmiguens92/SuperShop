using SuperShop.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class SeedDB
    {
        private readonly DataContext _context; //propriedade readonly pq é so pra bd

        private Random _random;

        public SeedDB(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync() //cria a seed assincrona
        {
            await _context.Database.EnsureCreatedAsync();//se a bd nao tiver criada ele cria 
            if(!_context.Products.Any())
            {
                AddProduct("iPhoneX");
                AddProduct("Magic Mouse");
                AddProduct("iWatch"); 
                AddProduct("iPad X");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product //cria os produtos
            { 
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
            });
        }
    }
}
