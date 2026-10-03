namespace Part3_BuilderPattern;

public class AddressBuilder
{
    private string? _street;
    private string? _city;
    private string? _state;
    private string? _zipCode;
    private string? _country;


    public AddressBuilder Street(string street)   { _street = street;   return this; }
    public AddressBuilder City(string city)       { _city = city;       return this; }
    public AddressBuilder State(string state)     { _state = state;     return this; }
    public AddressBuilder ZipCode(string zipCode) { _zipCode = zipCode; return this; }
    public AddressBuilder Country(string country) { _country = country; return this; }
    
    public Address Build () 
        => new Address(_street, _city, _state, _zipCode, _country);
    

}