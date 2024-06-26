namespace Backend.Profiles.Domain.Model.ValueObjects;

public record PhoneNumber(string Phone)
{
    public PhoneNumber() : this(String.Empty){}
}