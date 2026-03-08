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
    internal class PayPalPayment : IPaymentMethod
    {
        internal ILogger _logger { get; private set; }
        public PayPalPayment(ILogger logger) 
        {
            _logger = logger;
        }

        public string PaymentTypeString => PaymentType.PayPal.ToString();

        private bool VerifyPayPalCredential(Customer customer)
        {
            // do some verification
            // ...
            _logger.Info("PayPal account validated");
            return true;
        }
        
        public void Process(Customer customer, decimal amount)
        {
            _logger.Info("Validating PayPal account information");
            VerifyPayPalCredential(customer);

            _logger.Info(String.Format("Customer is charged: {0}", amount));
        }
    }
}
