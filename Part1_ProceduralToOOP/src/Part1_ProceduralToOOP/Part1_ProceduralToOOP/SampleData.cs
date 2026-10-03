namespace Part1_ProceduralToOOP;

public class SampleData
{
    public static void Seed(OrderSystem system)
    {
        system.AddCustomer(new Customer(1, "Mona Ali", "mona@example.com", "Cairo", true));
        system.AddCustomer(new Customer(2, "Omar Hassan", "omar@example.com", "Alexandria", false));
        system.AddCustomer(new Customer(3, "Sara Nabil", "sara@example.com", "Giza", false));
 
        system.AddProduct(new Product(101, "USB Cable", 50m, 100));
        system.AddProduct(new Product(102, "Wireless Mouse", 250m, 40));
        system.AddProduct(new Product(103, "Mechanical Keyboard", 1200m, 15));
        system.AddProduct(new Product(104, "Laptop Stand", 400m, 25));
    }
 
    public static void RunDemo(OrderSystem system)
    {
        system.CreateOrder(1001, 1, "2026-09-15");
        system.AddLineToOrder(1001, 101, 2);
        system.AddLineToOrder(1001, 102, 1);
        system.MarkOrderPaid(1001);
 
        system.CreateOrder(1002, 2, "2026-09-15");
        system.AddLineToOrder(1002, 103, 1);
        system.AddLineToOrder(1002, 104, 1);
 
        system.CreateOrder(1003, 3, "2026-09-16");
        system.AddLineToOrder(1003, 101, 5);
        system.MarkOrderPaid(1003);
    }
}