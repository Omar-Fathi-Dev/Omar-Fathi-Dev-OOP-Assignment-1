namespace Part1_ProceduralToOOP;

public class OrderSystem
{
    
    
    private const int MaxCustomers = 50;
    private const int MaxProducts = 50;
    private const int MaxOrders = 100;
 
    private readonly List<Customer> _customers = new();
    private readonly List<Product> _products = new();
    private readonly List<Order> _orders = new();
 
    public IReadOnlyList<Customer> Customers => _customers;
    public IReadOnlyList<Product> Products => _products;
    public IReadOnlyList<Order> Orders => _orders;
    
    
    public Customer? FindCustomer(int id)
    {
        for (int i = 0; i < _customers.Count; i++)
            if(_customers[i].Id == id)
                return _customers[i];
        return null;
    }
    public Product? FindProduct(int id)
    {
        for (int i = 0; i < _products.Count; i++)
            if(_products[i].Id == id)
                return _products[i];
        return null;
    }

    public Order? FindOrder(int id)
    {
        for (int i = 0; i < _orders.Count; i++)
            if(_orders[i].Id == id)
                return _orders[i];
        return null;
    }
    
    public void AddCustomer(Customer customer)
    {
        if (customer is null) throw new ArgumentNullException(nameof(customer));
        if (_customers.Count >= MaxCustomers) throw new InvalidOperationException("Customer list is full.");
        if (FindCustomer(customer.Id) is not null)
            throw new InvalidOperationException($"Customer id {customer.Id} already exists.");
        
        _customers.Add(customer);
    }
    
    public void AddProduct(Product product)
    {
        if (product is null) throw new ArgumentNullException(nameof(product));
        if (_products.Count >= MaxProducts) throw new InvalidOperationException("Product list is full.");
        if (FindProduct(product.Id) is not null)
            throw new InvalidOperationException($"Product id {product.Id} already exists.");
        
        _products.Add(product);
    }
    
    public Order CreateOrder(int orderId, int customerId, string date)
    {
        if (_orders.Count >= MaxOrders) throw new InvalidOperationException("Order list is full.");
        if (FindOrder(orderId) is not null) throw new InvalidOperationException($"Order id {orderId} already exists.");
        
        var customer = FindCustomer(customerId) ?? throw new ArgumentException($"Customer id {customerId} not found.");
        var order = new Order(orderId, customer, date);
        _orders.Add(order);
        return order;
    }
    
    public void AddLineToOrder(int orderId, int productId, int quantity)
        {
            var order = FindOrder(orderId) ?? throw new ArgumentException($"Order id {orderId} not found.");
            var product = FindProduct(productId) ?? throw new ArgumentException($"Product id {productId} not found.");
     
            order.AddLine(product, quantity);
        }
    
    public void MarkOrderPaid(int orderId)
    {
        var order = FindOrder(orderId) ?? throw new ArgumentException($"Order id {orderId} not found.");
        order.MarkPaid();
    }
    
    public decimal TotalSalesPaidOnly()
    {
        decimal sum = 0m;
        foreach (var order in _orders)
            if (order.IsPaid)
                sum += order.Total;
        return sum;
    }
}


