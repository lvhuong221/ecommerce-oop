using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Customers
{
    internal class VipCustomer(long id, string name, string address, string email) : Customer(id, name, address, email)
    {
        // VIP customer get extra discount for bigger order
        private static readonly (decimal MinAmount, decimal Rate)[] DiscountTiers =
        {
            (100000m, 0.30m), // 30% for $2000+
            (30000m, 0.25m), // 25%
            (5000m, 0.20m), // 20%
            (1000m,  0.15m), // 15%
            (100m,    0.10m)  // Base 10%
        };

        public override decimal GetDiscountAmount(decimal baseAmount)
        {
            // Find the first tier where the baseAmount is >= the threshold
            var (MinAmount, Rate) = DiscountTiers.FirstOrDefault(tier => baseAmount >= tier.MinAmount);

            return baseAmount * Rate;
        }
    }
}
