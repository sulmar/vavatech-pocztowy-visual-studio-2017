using Pocztowy.Models;
using System.Collections.Generic;

namespace Pocztowy.IRepositories
{

    public interface ICustomerRepository 
        : IEntityRepository<Customer, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        IEnumerator<Customer> Get(string city);
    }

}
