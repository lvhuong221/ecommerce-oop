using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Customers
{
    internal class PremiumCustomer(long id, string name, string address, string email) : Customer(id, name, address, email)
    {
        private readonly decimal discountPercentage = 0.1m; // Premium customer get a fixed discount

        public override decimal GetDiscountAmount(decimal baseAmount)
        {
            return baseAmount * discountPercentage;
        }
      
    }
}
