namespace Part1_ProceduralToOOP;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public int Stock { get; private set; }
    
    
    public Product(int id, string name, decimal price, int stock)
    {
        
        if (id < 0) throw new ArgumentException("Product ID cannot be negative.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Product name cannot be empty.");
        if (price < 0) throw new ArgumentException("Product price cannot be negative.");
        if (stock < 0) throw new ArgumentException("Product stock cannot be negative.");
 
        (Id, Name, Price, Stock) = (id, name, price, stock);
    }
    public void RemoveStock(int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive.");
        if (quantity > Stock) throw new InvalidOperationException($"Not enough stock for product #{Id}.");
        Stock -= quantity;
    }

    
    
    public override string ToString()
    {
        return $"#{Id}  {Name}  price={Price:F2}  stock={Stock}";
    }
}

