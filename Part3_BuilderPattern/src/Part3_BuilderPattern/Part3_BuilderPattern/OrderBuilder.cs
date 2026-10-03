namespace Part3_BuilderPattern;

public class OrderBuilder
{
    private DateOnly _orderDate;
    private string _paymentMethod;
    private string _currency;
    private decimal _subTotal;
    private decimal _discountAmount = 0m;
    private decimal _taxAmount = 0m;

    public OrderBuilder(DateOnly orderDate, string paymentMethod, string currency, decimal subTotal)
    {
        (_orderDate, _paymentMethod, _currency, _subTotal) =
            (orderDate, paymentMethod, currency, subTotal);
    }

    public OrderBuilder WithDiscount(decimal discountAmount)
    {
        _discountAmount = discountAmount; 
        return this;
    }

    public OrderBuilder WithTax(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    
    
    public Order Build()
        =>  new(_orderDate, _paymentMethod, _currency, _subTotal ,_discountAmount, _taxAmount);
}

