using BusinessManager.Interface;
using CommonLayer;
using RepositoryManager.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Services
{
   public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

       public IList<BulkUpdate> GetProduct()
       {
            var result = this.productRepository.GetProduct();
            return result;
       }



        public int AddProduct(BulkUpdate bulkUpdate)
        {
            var result = this.productRepository.AddProduct(bulkUpdate);
            return result;
        }

        public Task<IList<BulkUpdate>> MultipleUpdate(IList<BulkUpdate> productNumber, string status)
        {
            var result = this.productRepository.MultipleUpdate(productNumber, status);
            return result;
        }
        

    }
}
