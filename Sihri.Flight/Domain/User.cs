using Microsoft.AspNetCore.Identity;

namespace Sihri.Flight.Domain;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }

    public ICollection<ReservedFlights> ReservedFlightsCollection { get; set; }

}