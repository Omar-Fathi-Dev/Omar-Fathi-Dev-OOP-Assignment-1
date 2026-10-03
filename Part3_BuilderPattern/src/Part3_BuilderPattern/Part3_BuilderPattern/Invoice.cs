namespace Part3_BuilderPattern;

public class Invoice
{
    public int InvoiceId { get; }
    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public string? CustomerPhone { get; }
    
    public string BillingStreet { get; }
    public string BillingCity { get; }
    public string BillingState { get; }
    public string BillingZipCode { get; }
    public string BillingCountry { get; }
    
    public string ShippingStreet { get; }
    public string ShippingCity { get; }
    public string ShippingState { get; }
    public string ShippingZipCode { get; }
    public string ShippingCountry { get; }
    
    public DateOnly OrderDate { get; }
    public string PaymentMethod { get; }
    public string Currency { get; }
    public decimal SubTotal { get; }
    public decimal DiscountAmount { get; }
    public decimal TaxAmount { get; }
    public decimal TotalAmount => SubTotal - DiscountAmount + TaxAmount;
    
    // Mandatory:
       // InvoiceId, CustomerName, CustomerEmail,
       // Billing Address, OrderDate, PaymentMethod,
       // Currency and SubTotal.
    // Optional:
      // CustomerPhone, Shipping Address,
      // DiscountAmount and TaxAmount.

    public Invoice(
        int invoiceId, string customerName, string customerEmail, string? customerPhone,
        string billingStreet, string billingCity, string billingState,
        string billingZipCode, string billingCountry,
        string? shippingStreet, string? shippingCity, string? shippingState,
        string? shippingZipCode, string? shippingCountry,
        DateOnly orderDate, string paymentMethod, string currency,
        decimal subTotal, decimal discountAmount, decimal taxAmount)
    {
        if (invoiceId <= 0)
            throw new ArgumentException("Invoice id must be greater than 0.");
        if(string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Customer name must be specified.");
        if(string.IsNullOrWhiteSpace(customerEmail))
            throw new ArgumentException("Customer email must be specified.");
        if(string.IsNullOrWhiteSpace(billingStreet))
            throw new ArgumentException("Billing street must be specified.");
        if(string.IsNullOrWhiteSpace(billingCity))
            throw new ArgumentException("Billing city must be specified.");
        if(string.IsNullOrWhiteSpace(billingState))
            throw new ArgumentException("Billing state must be specified.");
        if(string.IsNullOrWhiteSpace(billingZipCode))
            throw new ArgumentException("Billing zip code must be specified.");
        if(string.IsNullOrWhiteSpace(billingCountry))
            throw new ArgumentException("Billing country must be specified.");
        if(orderDate == default)
            throw new ArgumentException("Order date is required.");
        if(string.IsNullOrWhiteSpace(paymentMethod))
            throw new ArgumentException("Payment method must be specified.");
        if(string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency must be specified.");
        if (subTotal < 0)
            throw new ArgumentException("SubTotal cannot be negative.");
        
        (InvoiceId, CustomerName, CustomerEmail , CustomerPhone) =
            (invoiceId, customerName, customerEmail ,customerPhone);
        
        (BillingStreet, BillingCity, BillingState, BillingZipCode ,BillingCountry ) =
            (billingStreet, billingCity, billingState, billingZipCode , billingCountry);
        
        (ShippingStreet, ShippingCity, ShippingState, ShippingZipCode, ShippingCountry) =
            (shippingStreet, shippingCity, shippingState, shippingZipCode, shippingCountry);
        
        OrderDate = orderDate;
        
        (PaymentMethod, Currency) =(paymentMethod, currency);
        
        (SubTotal, DiscountAmount , TaxAmount) = (subTotal, discountAmount ,  taxAmount);
        
            
        
        
    }
}


