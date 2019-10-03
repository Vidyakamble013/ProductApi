using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManager.Interface
{
   public interface IProductRepository
    {
        IList<BulkUpdate> GetProduct();

        int AddProduct(BulkUpdate bulkUpdate);

        Task<IList<BulkUpdate>> MultipleUpdate(IList<BulkUpdate> productNumber, string status);
       
    }
}
