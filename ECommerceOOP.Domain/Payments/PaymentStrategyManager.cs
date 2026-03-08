using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Payments
{
    internal class PaymentStrategyManager(IEnumerable<IPaymentMethod> strategies)
    {
        private readonly Dictionary<string, IPaymentMethod> _strategies = strategies.ToDictionary(
                s => s.PaymentTypeString.ToLower(),
                s => s
            );

        public IPaymentMethod GetStrategy(string customerType)
        {
            if (_strategies.TryGetValue(customerType.ToLower(), out var strategy))
            {
                return strategy;
            }
            throw new Exception("Strategy not found!");
        }
    }
}
