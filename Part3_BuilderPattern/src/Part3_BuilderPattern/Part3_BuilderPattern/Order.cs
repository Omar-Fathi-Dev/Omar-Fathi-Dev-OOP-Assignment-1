namespace Part3_BuilderPattern;

public class Order
{
    public DateOnly OrderDate { get; }
    public string PaymentMethod { get; }
    public string Currency { get; }
    public decimal SubTotal { get; }
    public decimal DiscountAmount { get; }
    public decimal TaxAmount { get; }
    public decimal TotalAmount => SubTotal - DiscountAmount + TaxAmount;

    public Order(DateOnly orderDate, string paymentMethod, string currency, decimal subTotal, decimal discountAmount, decimal taxAmount)
    {
        if(orderDate == default)
            throw new ArgumentException("Order date is required.");
        if(string.IsNullOrWhiteSpace(paymentMethod))
            throw new ArgumentException("Payment method must be specified.");
        if(string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency must be specified.");
        if (subTotal < 0)
            throw new ArgumentException("SubTotal cannot be negative.");
        if (discountAmount < 0) throw new ArgumentException("Discount cannot be negative.");
        if (discountAmount > subTotal) throw new ArgumentException("Discount cannot be bigger than SubTotal.");
        if (taxAmount < 0) throw new ArgumentException("Tax cannot be negative.");
        
        (OrderDate ,  PaymentMethod, Currency, SubTotal, DiscountAmount, TaxAmount) =
            (orderDate, paymentMethod, currency, subTotal, discountAmount, taxAmount);
    }
}

