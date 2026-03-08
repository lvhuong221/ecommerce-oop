using ECommerceOOP.ECommerceOOP.Domain.Customers;
using ECommerceOOP.ECommerceOOP.Domain.Logging;
using ECommerceOOP.ECommerceOOP.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Payments
{
    internal class CreditCardPayment : IPaymentMethod
    {
        internal ILogger _logger { get; private set; }
        public CreditCardPayment(ILogger logger)
        {
            _logger = logger;
        }
        public string PaymentTypeString => PaymentType.CreditCard.ToString();

        private bool VerifyCreditCardInfo(Customer customer)
        {
            _logger.Info("Validating credit card information");
            // do some verification
            // ...
            _logger.Info("Credit card information validated");
            return true;
        }

        public void Process(Customer customer, decimal amount)
        {
            VerifyCreditCardInfo(customer);
            _logger.Info("Calculating discount");

            _logger.Info(String.Format("Customer is charged: {0}", amount));
        }
    }
}
