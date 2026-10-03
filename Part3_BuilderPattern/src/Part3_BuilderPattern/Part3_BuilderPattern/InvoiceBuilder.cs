namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private readonly int _invoiceId;
    private readonly string _customerName;
    private readonly string _customerEmail;
    private readonly string _billingStreet;
    private readonly string _billingCity;
    private readonly string _billingState;
    private readonly string _billingZipCode;
    private readonly string _billingCountry;
    private readonly DateOnly _orderDate;
    private readonly string _paymentMethod;
    private readonly string _currency;
    private readonly decimal _subTotal;

    private string? _customerPhone;
    private string? _shippingStreet;
    private string? _shippingCity;
    private string? _shippingState;
    private string? _shippingZipCode;
    private string? _shippingCountry;
    private decimal _discountAmount = 0m;
    private decimal _taxAmount = 0m;
    
    public InvoiceBuilder(
        int invoiceId, string customerName, string customerEmail,
        string billingStreet, string billingCity, string billingState,
        string billingZipCode, string billingCountry,
        DateOnly orderDate, string paymentMethod, string currency, decimal subTotal)
    {
        (_invoiceId, _customerName, _customerEmail) = (invoiceId, customerName, customerEmail);
        (_billingStreet, _billingCity, _billingState) = (billingStreet, billingCity, billingState);
        (_billingZipCode, _billingCountry) = (billingZipCode, billingCountry);
        (_orderDate,_paymentMethod, _currency, _subTotal) = (orderDate, paymentMethod, currency, subTotal);
    }
    
    public InvoiceBuilder WithPhone(string phone)
    {
        _customerPhone = phone;
        return this;
    }

    public InvoiceBuilder WithShippingStreet(string street)
    {
        _shippingStreet = street;
        return this;
    }

    public InvoiceBuilder WithShippingCity(string city)
    {
        _shippingCity = city;
        return this;
    }

    public InvoiceBuilder WithShippingState(string state)
    {
        _shippingState = state;
        return this;
    }

    public InvoiceBuilder WithShippingZipCode(string zipCode)
    {
        _shippingZipCode = zipCode;
        return this;
    }

    public InvoiceBuilder WithShippingCountry(string country)
    {
        _shippingCountry = country;
        return this;
    }

    public InvoiceBuilder WithDiscount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public InvoiceBuilder WithTax(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public Invoice Build()
    {
        return new Invoice(_invoiceId, _customerName, _customerEmail , _customerPhone,
            _billingStreet, _billingCity, _billingState, _billingZipCode,_billingCountry,
            _shippingStreet, _shippingCity, _shippingState, _shippingZipCode,_shippingCountry,
            _orderDate, _paymentMethod, _currency, _subTotal, _discountAmount, _taxAmount);
    }
    
    
}