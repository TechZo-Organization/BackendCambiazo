using System.Text.Json.Serialization;
using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands;
using Backend.Profiles.Domain.Model.ValueObjects;

namespace Backend.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Phone = new PhoneNumber();
        Photo = new ProfilePhoto();
    }

    public Profile(string firstName, string lastName, string email, int phone, string photo)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Phone = new PhoneNumber(phone);
        Photo = new ProfilePhoto(photo);
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Phone = new PhoneNumber(command.Phone);
        Photo = new ProfilePhoto(command.Photo);
    }
    
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public ProfilePhoto Photo { get; private set; }
    
    [JsonIgnore]
    public ICollection<Product> Products { get; set; }
    [JsonIgnore]
    public ICollection<FavoriteProduct> FavoriteProducts { get; set; }

    public string FullName => Name.FullName;
    
    public string EmailAddress => Email.Address;
    
    public int PhoneNumber => Phone.Phone;

    public string ProfilePhoto => Photo.Photo;
}