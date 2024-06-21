namespace Backend.Profiles.Domain.Model.ValueObjects;

public record PhoneNumber(int Phone)
{
    public PhoneNumber() : this(Phone:0){}
}