using ECommerceOOP.ECommerceOOP.Domain.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Customers
{
    internal abstract class Customer(long id, string name, string address, string email)
    {

        internal long Id { get; private set; } = id;
        internal string Name { get; private set; } = name;
        internal string Address { get; private set; } = address;
        internal string Email { get; private set; } = email;

        public virtual decimal GetDiscountAmount(decimal baseAmount)
        {
            return baseAmount;
        }
    }
}
