using System.Text;

namespace Part1_ProceduralToOOP;

public class Order
{
    
    public const int MaxLines = 20;
 
    private readonly List<OrderLine> _lines = new();
    private readonly decimal _discountRate; 
 
    public int Id { get; }
    public Customer Customer { get; }
    public string Date { get; }
    public bool IsPaid { get; private set; }
    public IReadOnlyList<OrderLine> Lines => _lines;
 
    public decimal Subtotal => _lines.Sum(l => l.LineTotal);
    public decimal Total => Subtotal * (1 - _discountRate);
    

    public Order(int id, Customer customer, string date)
    {
        if (customer is null) throw new ArgumentNullException(nameof(customer));
        if (id < 0) throw new ArgumentException("Order ID cannot be negative.");
        if (string.IsNullOrWhiteSpace(date)) throw new ArgumentException("Order date cannot be empty.");
 
        (Id, Customer, Date) = (id, customer, date);
        _discountRate = customer.DiscountRate;
    }
    
    public void AddLine(Product product, int quantity)
    {
        if (product is null) throw new ArgumentNullException(nameof(product));
 
        if (IsPaid) throw new InvalidOperationException("Cannot change a paid order.");
        if (_lines.Count >= MaxLines) throw new InvalidOperationException("Order has too many lines.");
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive.");
 
        product.RemoveStock(quantity); 
        _lines.Add(new OrderLine(product, quantity));
    }
    
    public void MarkPaid()
    {
        if (_lines.Count == 0) throw new InvalidOperationException("Cannot pay an empty order.");
        IsPaid = true;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"=== ORDER #{Id} ===");
        sb.AppendLine($"Date: {Date}");
        sb.AppendLine($"Customer: {Customer.Name} (#{Customer.Id})");
        sb.AppendLine($"Paid: {(IsPaid ? "yes" : "no")}");
        sb.AppendLine("Lines:");
        foreach (var line in _lines)
            sb.AppendLine(line.ToString());
        sb.AppendLine($"Subtotal: {Subtotal:F2}");
        if (_discountRate > 0)
            sb.AppendLine($"VIP discount ({_discountRate:P0}): -{Subtotal * _discountRate:F2}");
        sb.Append($"TOTAL: {Total:F2}");
        return sb.ToString();
    }
}





