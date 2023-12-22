namespace CW12_1.Models;

public class Address
{
    public Address()
    {
        AddressID = Guid.NewGuid().ToString();
    }

    public string AddressName { get; set; }
    public string AddressID { get; set; }

    
}
