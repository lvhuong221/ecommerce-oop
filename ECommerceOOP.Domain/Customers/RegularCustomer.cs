using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Customers
{
    internal class RegularCustomer(long id, string name, string address, string email) : Customer(id, name, address, email)
    {
        public override decimal GetDiscountAmount(decimal baseAmount)
        {
            return 0; // no discount for regular customer
        }
    }
}
