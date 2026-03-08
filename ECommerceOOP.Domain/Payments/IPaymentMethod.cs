using ECommerceOOP.ECommerceOOP.Domain.Customers;
using ECommerceOOP.ECommerceOOP.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Payments
{
    internal interface IPaymentMethod
    {
        string PaymentTypeString { get; }
        void Process(Customer customer, decimal amount);
    }
}
