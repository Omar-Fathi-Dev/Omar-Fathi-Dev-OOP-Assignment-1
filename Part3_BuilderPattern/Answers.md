# Task 3.1 : 

## Question 1:
Why is a 20-parameter constructor a problem?

**1. It is hard to read.**
Look at this call:

```csharp
new Invoice(1001, "Omar Fathi", "omar@example.com", "01012345678",
    "12 Nile St", "Cairo", "Cairo", "11511", "Egypt",
    "5 Park Rd", "Giza", "Mansoura", "12611", "Egypt",
    date, "Card", "EGP", 350m, 35m, 20m, 335m);
```

I cannot tell what each value means. I must open the class and count the values one by one.

**2. It is easy to put values in the wrong order.**
Many values have the same type:`SubTotal`, `DiscountAmount`, `TaxAmount` and `TotalAmount` are all `decimal`.

If I swap two of them, the code still compiles. The compiler does not warn me.
The program runs, but the data is wrong.

**3. Adding a new property is painful.**
If someone adds one new optional property:
- every place that calls the constructor must change, or
- we make a second constructor, then a third one, and so on.

## Question 2:
Is it only a "constructor is too long" problem?

No. The real problem is that one class does too many things.

This one class holds four different groups of data:
- customer information
- billing address
- shipping address
- order and payment information

These groups are different. They change for different reasons.

# Task 3.3:
Why is the composed version better?

In Task 3.2, one big builder did everything.
In Task 3.3, I use small builders: `AddressBuilder`, `OrderBuilder` and `InvoiceBuilder`.

## 1. Single responsibility

Each builder has one job:
- `AddressBuilder` builds an address.
- `OrderBuilder` builds the order and payment data.
- `InvoiceBuilder` puts the parts together with the customer data.


## 2. Independent validation

Yes. `AddressBuilder` and `Address` check the address by themselves.
`Invoice` does not know the rules of an address.

## 3. Reuse

I use the same `AddressBuilder` for billing and for shipping.

## 4. Readability at the call site

Task 3.2:

    new InvoiceBuilder(1001, "Mona Ali", "mona@example.com",
        "12 Nile St", "Cairo", "Cairo", "11511", "Egypt",
        new DateOnly(2026, 10, 3), "Card", "EGP", 350m)
        .WithShippingStreet("5 Park Rd")
        .WithShippingCity("Giza")
        ...
        .Build();

There are 12 values in the constructor, and many are strings.

Task 3.3:

    Address billing = new AddressBuilder()
        .Street("12 Nile St").City("Cairo").State("Cairo")
        .ZipCode("11511").Country("Egypt").Build();

    Order order = new OrderBuilder(new DateOnly(2026, 10, 3), "Card", "EGP", 350m)
        .WithDiscount(35m).WithTax(20m).Build();

    Invoice invoice = new InvoiceBuilder(1001, "Mona Ali", "mona@example.com", billing, order)
        .WithPhone("01012345678")
        .Build();

Now every value has a name, like `.City("Cairo")`.

## One cost

The composed version has more classes.
But for a big object with repeated parts, it is worth it.