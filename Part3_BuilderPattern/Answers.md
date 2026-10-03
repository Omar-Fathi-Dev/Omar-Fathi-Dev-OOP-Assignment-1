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