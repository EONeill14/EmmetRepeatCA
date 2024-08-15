using Microsoft.EntityFrameworkCore;

namespace EmmetRepeatCA.Models
{

    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;

        public EFOrderRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
                            .Include(o => o.Lines)
                            .ThenInclude(l => l.Vinyl); 

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Vinyl));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
