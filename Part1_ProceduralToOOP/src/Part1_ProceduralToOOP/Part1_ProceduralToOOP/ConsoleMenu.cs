namespace Part1_ProceduralToOOP;

public class ConsoleMenu
{
    private readonly OrderSystem _system;
 
    public ConsoleMenu(OrderSystem system)
    {
        _system = system ?? throw new ArgumentNullException(nameof(system));
    }
    
    private void PrintCustomers()
    {
        Console.WriteLine($"\n=== CUSTOMERS ({_system.Customers.Count}) ===");
        foreach (var c in _system.Customers)
            Console.WriteLine(c);
    }
    private void PrintProducts()
    {
        Console.WriteLine($"\n=== PRODUCTS ({_system.Products.Count}) ===");
        foreach (var p in _system.Products)
            Console.WriteLine(p);
    }
    private void PrintAllOrders()
    {
        Console.WriteLine($"\n=== ALL ORDERS ({_system.Orders.Count}) ===");
        foreach (var o in _system.Orders)
            Console.WriteLine($"\n{o}");
    }
    public void ShowOverview()
    {
        PrintCustomers();
        PrintProducts();
        PrintAllOrders();
        Console.WriteLine($"\nPaid sales total after demo: {_system.TotalSalesPaidOnly():F2}");
    }
    
    private static void PrintMenu()
    {
        Console.WriteLine("\n---------- MENU ----------");
        Console.WriteLine("1) Print customers");
        Console.WriteLine("2) Print products");
        Console.WriteLine("3) Print all orders");
        Console.WriteLine("4) Print one order by id");
        Console.WriteLine("5) Create order");
        Console.WriteLine("6) Add line to order");
        Console.WriteLine("7) Mark order paid");
        Console.WriteLine("8) Show paid sales total");
        Console.WriteLine("0) Exit");
    }
    
    private static int ReadInt(string? input)
    {
        while (true)
        {
            Console.Write(input ?? "Choice: ");
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;
            Console.WriteLine("Please enter a valid number.");
        }
    }
    private static string ReadString(string input)
    {
        Console.Write(input);
        return Console.ReadLine()?.Trim() ?? "";
    }
    
    private void CreateOrder()
    {
        int orderId = ReadInt("Order id: ");
        int customerId = ReadInt("Customer id: ");
        string date = ReadString("Date (YYYY-MM-DD): ");
        _system.CreateOrder(orderId, customerId, date);
        Console.WriteLine($"Order #{orderId} created.");
    }
    
    private void AddLine()
    {
        int orderId = ReadInt("Order id: ");
        int productId = ReadInt("Product id: ");
        int quantity = ReadInt("Quantity: ");
        _system.AddLineToOrder(orderId, productId, quantity);
        Console.WriteLine("Line added.");
    }
 
    private void PayOrder()
    {
        int orderId = ReadInt("Order id: ");
        _system.MarkOrderPaid(orderId);
        Console.WriteLine($"Order #{orderId} marked as paid.");
    }
    
    
    private void PrintOneOrder()
    {
        int id = ReadInt("Order id: ");
        Console.WriteLine($"\n{_system.FindOrder(id) ?? throw new ArgumentException($"Order id {id} not found.")}");
    }
    
    public void Run()
    {
        int choice = -1;
        while (choice != 0)
        {
            PrintMenu();
            choice = ReadInt(null);
 
            try
            {
                switch (choice)
                {
                    case 1: PrintCustomers(); break;
                    case 2: PrintProducts(); break;
                    case 3: PrintAllOrders(); break;
                    case 4: PrintOneOrder(); break;
                    case 5: CreateOrder(); break;
                    case 6: AddLine(); break;
                    case 7: PayOrder(); break;
                    case 8: Console.WriteLine($"Paid sales total: {_system.TotalSalesPaidOnly():F2}"); break;
                    case 0: Console.WriteLine("Bye."); break;
                    default: Console.WriteLine("Unknown choice."); break;
                }
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }

}

