namespace Backend.Profiles.Domain.Model.ValueObjects;

public record PersonName(string FirstName)
{
    public PersonName() : this(string.Empty)
    {
        
    }
    public string FullName => FirstName;
}