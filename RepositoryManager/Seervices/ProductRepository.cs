using CommonLayer;
using RepositoryManager.Context;
using RepositoryManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManager.Seervices
{
   public class ProductRepository : IProductRepository
    {
        private readonly ProductContext productContext;

        public ProductRepository(ProductContext context)
        {
            this.productContext = context;
        }

       public IList<BulkUpdate> GetProduct()
       {
            var product = this.productContext.Product.ToList<BulkUpdate>();
            return product;
       }

        public int AddProduct(BulkUpdate bulkUpdate)
        {
            try
            {
                BulkUpdate bulk = new BulkUpdate()
                {
                    ProductName = bulkUpdate.ProductName,
                    ProductNumber = bulkUpdate.ProductNumber,
                    Status = bulkUpdate.Status,
                };
                this.productContext.Product.Add(bulk);
                var result =  this.productContext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

       public Task<IList<BulkUpdate>> MultipleUpdate(IList<BulkUpdate> productNumber, string status)
        {
            IList<BulkUpdate> listOfProducts = new List<BulkUpdate>();
            listOfProducts = this.productContext.Product.Select(x => new BulkUpdate
            {
                ProductNumber = x.ProductNumber
            }).ToList();

            IEnumerable<BulkUpdate> invalidProdutNumber = new List<BulkUpdate>();
            invalidProdutNumber = listOfProducts.Except(productNumber);

            var result = listOfProducts.Where<BulkUpdate>(c => c.ProductNumber.Equals(productNumber)).FirstOrDefault();
            foreach(var item in listOfProducts)
            {
                item.Status = status;
            }
            if (invalidProdutNumber != null)
            {
                throw new Exception( invalidProdutNumber.ToString());
            }
            else
            {
                return null;
            }

        }

    }
}
