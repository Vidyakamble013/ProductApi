using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
   public interface IProductManager
    {
        IList<BulkUpdate> GetProduct();

        int AddProduct(BulkUpdate bulkUpdate);

        Task<IList<BulkUpdate>> MultipleUpdate(IList<BulkUpdate> productNumber, string status);

    }
}
