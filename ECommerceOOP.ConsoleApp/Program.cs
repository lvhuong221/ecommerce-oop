// See https://aka.ms/new-console-template for more information
using ECommerceOOP.ECommerceOOP.Domain.Customers;
using ECommerceOOP.ECommerceOOP.Domain.Logging;
using ECommerceOOP.ECommerceOOP.Domain.Orders;
using ECommerceOOP.ECommerceOOP.Domain.Payments;
using ECommerceOOP.ECommerceOOP.Domain.Utils;
using Microsoft.Extensions.DependencyInjection;

#region Dependency injection
var services = new ServiceCollection();

// Register payment methods
services.AddSingleton<IPaymentMethod, CreditCardPayment>();
services.AddSingleton<IPaymentMethod, PayPalPayment>();
services.AddSingleton<ILogger, ConsoleLogger>();

// Register the Manager
services.AddSingleton<PaymentStrategyManager>();

// Build the Provider
var serviceProvider = services.BuildServiceProvider();
#endregion

RegularCustomer customer = MockDataUtils.GenerateRegularCustomers();
PremiumCustomer premiumCustomer = MockDataUtils.GeneratePremiumCustomers();
VipCustomer vipCustomer = MockDataUtils.GenerateVIPCustomers();

var manager = serviceProvider.GetRequiredService<PaymentStrategyManager>();

IPaymentMethod creditCardPayment = manager.GetStrategy("CreditCard");
IPaymentMethod payPalPayment = manager.GetStrategy("CreditCard");

ILogger logger = serviceProvider.GetRequiredService<ILogger>();

Order order1 = new Order(1, customer, "Mock order 1", "Desc", 100m);
order1.ProcessOrder(creditCardPayment, logger);

Console.WriteLine("_______________________________________________");
Order order2 = new Order(2, premiumCustomer, "Mock order 2", "Desc", 1600m);
order2.ProcessOrder(creditCardPayment, logger);

Console.WriteLine("_______________________________________________");
Order order3 = new Order(3, vipCustomer, "Mock order 3", "Desc", 977890900m);
order3.ProcessOrder(payPalPayment, logger);

Console.WriteLine("_______________________________________________");
// Bad order
Order order4 = new Order(4, vipCustomer, "Mock order 4", "Desc", -1234567m);
order4.ProcessOrder(payPalPayment, logger);