using Pocztowy.IRepositories;
using Pocztowy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pocztowy.FakeRepositories
{

    public class FakeCustomerRepository
        : FakeEntityRepository<Customer, int>, ICustomerRepository
    {
        public FakeCustomerRepository()
        {
        }

        public IEnumerator<Customer> Get(string city)
        {
            throw new NotImplementedException();
        }


        public Customer GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }


        public override void Remove(int id)
        {
            Customer customer = Get(id);
            customer.IsRemoved = true;
        }

    }
}
