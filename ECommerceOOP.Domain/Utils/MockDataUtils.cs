using Bogus;
using ECommerceOOP.ECommerceOOP.Domain.Customers;

namespace ECommerceOOP.ECommerceOOP.Domain.Utils
{
    public static class MockDataUtils
    {

        internal static RegularCustomer GenerateRegularCustomers()
        {
            var customerFaker = new Faker<RegularCustomer>()
                // Since setters are private, we use the constructor
                .CustomInstantiator(f => new RegularCustomer(
                    id: f.IndexGlobal, // Incremental ID
                    name: f.Name.FullName(),
                    address: f.Address.FullAddress(),
                    email: f.Internet.Email()
                ));

            return customerFaker.Generate();
        }

        internal static PremiumCustomer GeneratePremiumCustomers()
        {
            var customerFaker = new Faker<PremiumCustomer>()
                // Since setters are private, we use the constructor
                .CustomInstantiator(f => new PremiumCustomer(
                    id: f.IndexGlobal, // Incremental ID
                    name: f.Name.FullName(),
                    address: f.Address.FullAddress(),
                    email: f.Internet.Email()
                ));

            return customerFaker.Generate();
        }

        internal static VipCustomer GenerateVIPCustomers()
        {
            var customerFaker = new Faker<VipCustomer>()
                // Since setters are private, we use the constructor
                .CustomInstantiator(f => new VipCustomer(
                    id: f.IndexGlobal, // Incremental ID
                    name: f.Name.FullName(),
                    address: f.Address.FullAddress(),
                    email: f.Internet.Email()
                ));

            return customerFaker.Generate();
        }
    }
}
