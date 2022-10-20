namespace Sihri.Visa.Domain;

public class AppliedVisa
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; }
    public User AppliedByUser { get; set; }
}