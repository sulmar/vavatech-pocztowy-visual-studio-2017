using Pocztowy.IRepositories;
using Pocztowy.Models;

namespace Pocztowy.FakeRepositories
{
    public class FakeOrderRepository
        : FakeEntityRepository<Order, long>, IOrderRepository
    {

    }
}
