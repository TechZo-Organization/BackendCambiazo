namespace Backend.Profiles.Domain.Model.ValueObjects;

public record ProfilePhoto(string Photo)
{
    public ProfilePhoto() : this(string.Empty){}
}