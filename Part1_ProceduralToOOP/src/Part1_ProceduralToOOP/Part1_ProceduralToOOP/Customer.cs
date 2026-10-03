namespace Part1_ProceduralToOOP;

public class Customer
{
    private const decimal VipDiscountRate = 0.10m; 
    public decimal DiscountRate => IsVip ? VipDiscountRate : 0m;
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string City { get; }
    public bool IsVip { get; }
    
    public Customer(int id, string name, string email, string city, bool isVip)
    {
        if (id < 0) throw new ArgumentException("Customer ID cannot be negative.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty.");
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be empty.");
        (Id, Name, Email, City, IsVip) = (id, name, email, city, isVip);
    }
    

    public override string ToString()
    {
        return $"#{Id}  {Name}  <{Email}>  {City}  vip={(IsVip ? "yes" : "no")}";
    }
}




