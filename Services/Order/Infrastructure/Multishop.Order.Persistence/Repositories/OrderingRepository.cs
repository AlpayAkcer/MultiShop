using Multishop.Order.Domain.Entities;
using Multishop.Order.Persistence.Context;
using MultiShop.Order.Application.Interfaces;

namespace Multishop.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _orderContext;

        public OrderingRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        //Orderings user id sine göre yazdığımız entity özgü bir method bunu yazdıktan sonra handler tarafına geçmemiz gerekiyor.
        public List<Ordering> GetOrderingByUserId(string id)
        {
            var values = _orderContext.Orderings.Where(x => x.UserId == id).ToList();
            return values;
        }

        public int GetOrderTotalCount()
        {
            var values = _orderContext.Orderings.Count();
            return values;
        }
    }
}
