using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Orders.OrderCreated
{
    public static class Database
    {
        private static int Id = 0;
        internal static string SaveOrder(string[] productIds, string userId, string shippingTypeId)
        {
            var nextOrderId = Id++;
            return nextOrderId.ToString();
        }
    }
}
