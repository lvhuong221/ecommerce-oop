using ECommerceOOP.ECommerceOOP.Domain.Customers;
using ECommerceOOP.ECommerceOOP.Domain.Logging;
using ECommerceOOP.ECommerceOOP.Domain.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Orders
{
    internal class Order(long id, Customer customer, string name, string desciption, decimal price)
    {
        public long Id { get; private set; } = id;
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = desciption;
        public decimal Price { get; private set; } = price;
        public Customer Customer { get; private set; } = customer;

        public decimal customerDiscount => Customer.GetDiscountAmount(Price);
        public decimal FinalPrice => Price - customerDiscount;

        public void ProcessOrder(IPaymentMethod paymentMethod, ILogger logger)
        {
            ArgumentNullException.ThrowIfNull(paymentMethod);

            ArgumentNullException.ThrowIfNull(Customer);

            try
            {
                if (Price <= 0)
                {
                    logger.Error($"Invalid Order Price: {Price:C}. Order ID: {Id}");
                    throw new InvalidOperationException("Cannot process an order with a zero or negative price.");
                }

                logger.Info($"Starting payment for Order of {Price:C}...");
                paymentMethod.Process(Customer, FinalPrice);
                logger.Info("Payment completed successfully.");
            }
            catch (Exception ex)
            {
                logger.Error($"Payment failed for {Customer.Name}. Reason: {ex.Message}");

                throw;
            }
        }
    }
}
