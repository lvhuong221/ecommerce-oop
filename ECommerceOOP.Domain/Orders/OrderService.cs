using ECommerceOOP.ECommerceOOP.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Orders
{
    internal class OrderService(PaymentStrategyManager paymentStrategyManager)
    {
        private readonly PaymentStrategyManager _paymentStrategyManager = paymentStrategyManager;

        public void ProcessOrder(Order order, string paymentMethodString)
        {
            IPaymentMethod srtategy = _paymentStrategyManager.GetStrategy(paymentMethodString);
            //srtategy.Process(order);
        }
    }
}
