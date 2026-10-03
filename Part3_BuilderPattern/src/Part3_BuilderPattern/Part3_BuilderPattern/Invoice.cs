namespace Part3_BuilderPattern;

public class Invoice
{
    // Mandatory:
    // InvoiceId, CustomerName, CustomerEmail,
    // Billing Address, OrderDate, PaymentMethod,
    // Currency and SubTotal.
    // Optional:
    // CustomerPhone, Shipping Address,
    // DiscountAmount and TaxAmount.
    
    public int InvoiceId { get; }
    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public string? CustomerPhone { get; }
    public Address BillingAddress { get; }
    public Address ShippingAddress { get; }
    public Order Order { get; }
    public decimal TotalAmount => Order.TotalAmount;
    
    

    public Invoice(int invoiceId, string customerName, string customerEmail, string? customerPhone,
        Address billingAddress, Address? shippingAddress, Order order)
    {
        if (invoiceId <= 0)
            throw new ArgumentException("Invoice id must be greater than 0.");
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Customer name is required.");
        if (string.IsNullOrWhiteSpace(customerEmail) || !customerEmail.Contains('@'))
            throw new ArgumentException("Customer email is required and must contain '@'.");
        if (customerPhone is not null && string.IsNullOrWhiteSpace(customerPhone))
            throw new ArgumentException("Customer phone cannot be empty when it is given.");
        ArgumentNullException.ThrowIfNull(billingAddress);
        ArgumentNullException.ThrowIfNull(order);

        (InvoiceId, CustomerName, CustomerEmail, CustomerPhone) =
            (invoiceId, customerName, customerEmail, customerPhone);
        
        BillingAddress = billingAddress;
        ShippingAddress = shippingAddress;  
        Order = order;
    }
}




