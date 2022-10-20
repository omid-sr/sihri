using Microsoft.AspNetCore.Identity;

namespace Sihri.Visa.Domain;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public List<AppliedVisa> AppliedVisas { get; set; }

}