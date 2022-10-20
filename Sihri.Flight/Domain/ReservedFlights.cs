namespace Sihri.Flight.Domain;

public class ReservedFlights
{
    public Guid Id { get; set; }
    public User AppliedByUser { get; set; }
    public Guid UserId { get; set; }
}