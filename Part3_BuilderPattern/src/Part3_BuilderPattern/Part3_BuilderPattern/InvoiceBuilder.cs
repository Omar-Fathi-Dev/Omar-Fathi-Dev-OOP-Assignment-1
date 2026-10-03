namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private readonly int _invoiceId;
    private readonly string _customerName;
    private readonly string _customerEmail;
    private readonly Address _billingAddress;
    private readonly Order _order;

    private string? _customerPhone;
    private Address? _shippingAddress;
    
    public InvoiceBuilder(int invoiceId, string customerName, string customerEmail,
        Address billingAddress, Order order)
    {
        (_invoiceId, _customerName, _customerEmail) = (invoiceId, customerName, customerEmail);
        (_billingAddress, _order) = (billingAddress, order);
    }

    public InvoiceBuilder WithShippingAddress(Address shippingAddress)
    {
        _shippingAddress = shippingAddress;
        return this;
    }
    
    public InvoiceBuilder WithPhone(string phone)
    {
        _customerPhone = phone;
        return this;
    }

    
    public Invoice Build()
    {
        return new Invoice(_invoiceId, _customerName, _customerEmail, _customerPhone,
            _billingAddress, _shippingAddress, _order);
    }
    
    
}

