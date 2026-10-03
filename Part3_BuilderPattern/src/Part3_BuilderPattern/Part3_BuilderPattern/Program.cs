namespace Part3_BuilderPattern;

class Program
{
    static void Main(string[] args)
    {
        Address billing = new AddressBuilder()
            .Street("12 Nile St")
            .City("Cairo")
            .State("Cairo")
            .ZipCode("11511")
            .Country("Egypt")
            .Build();
        
        Order order = new OrderBuilder(new DateOnly(2026, 10, 3), "Card", "EGP", 350m)
            .WithDiscount(35m)
            .WithTax(20m)
            .Build();

        Invoice invoice = new InvoiceBuilder(1001, "Omar Fathi", "Omar@example.com", billing, order)
            .WithPhone("01012345678")
            .Build();
        
         
         
        Console.WriteLine("Invoice #" + invoice.InvoiceId + " for " + invoice.CustomerName);
        Console.WriteLine("Billing city:  " + invoice.BillingAddress.City);
        if (invoice.ShippingAddress is null)
            Console.WriteLine("Shipping address: none (it is optional)");
        else
            Console.WriteLine("Shipping city: " + invoice.ShippingAddress.City);
        Console.WriteLine("Total: " + invoice.TotalAmount);  
        
        
        Console.WriteLine();
        try
        {
            Address bad = new AddressBuilder()
                .Street("5 Park Rd")
                .State("Giza")
                .ZipCode("12611")
                .Country("Egypt")
                .Build();
 
            Console.WriteLine("Address created.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Rejected: " + ex.Message);
        }





    }
}