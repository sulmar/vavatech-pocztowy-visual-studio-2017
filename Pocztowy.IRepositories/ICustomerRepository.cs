using Pocztowy.Models;
using System.Collections.Generic;

namespace Pocztowy.IRepositories
{

    public interface ICustomerRepository 
        : IEntityRepository<Customer, int>
    {
        IEnumerator<Customer> Get(string city);
    }

}
