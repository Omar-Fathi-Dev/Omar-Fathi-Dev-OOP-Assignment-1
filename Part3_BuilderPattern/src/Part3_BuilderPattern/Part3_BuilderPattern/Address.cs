namespace Part3_BuilderPattern;

public class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }
    public string Country { get; }

    public Address(string street, string city, string state, string zipCode, string country)
    {
        if(string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street must be specified.");
        if(string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City must be specified.");
        if(string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State must be specified.");
        if(string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentException("Zip code must be specified.");
        if(string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country must be specified.");
        (Street ,  City, State, ZipCode, Country) = (street, city, state, zipCode, country);
    }
}

