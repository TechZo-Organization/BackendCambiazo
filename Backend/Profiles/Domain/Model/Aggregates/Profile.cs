using System.Text.Json.Serialization;
using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands;
using Backend.Profiles.Domain.Model.Entities;
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
        MembershipId = 1;
    }

    public Profile(string firstName, string email, string phone, string photo, int membershipId)
    {
        Name = new PersonName(firstName);
        Email = new EmailAddress(email);
        Phone = new PhoneNumber(phone);
        Photo = new ProfilePhoto(photo);
        MembershipId = membershipId;
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.Name);
        Email = new EmailAddress(command.Email);
        Phone = new PhoneNumber(command.Phone);
        Photo = new ProfilePhoto(command.Photo);
        MembershipId = command.MembershipId;
    }
    
    public void Update(UpdateProfileCommand command)
    {
        Name = new PersonName(command.Name);
        Email = new EmailAddress(command.Email);
        Phone = new PhoneNumber(command.Phone);
        Photo = new ProfilePhoto(command.Photo);
        MembershipId = command.MembershipId;

    }
    
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public ProfilePhoto Photo { get; private set; }
    
    [JsonIgnore]
    public ICollection<Product> Products { get; internal set; }
    [JsonIgnore]
    public ICollection<FavoriteProduct> FavoriteProducts { get; internal set; }
    public int MembershipId { get; set; }
    public Membership Membership { internal get; set; }
    [JsonIgnore]
    public ICollection<Review> ReviewsAuthor { get; internal set; }
    [JsonIgnore]
    public ICollection<Review> ReviewsReceptor { get; internal set; }

    public string FullName => Name.FullName;
    
    public string EmailAddress => Email.Address;
    
    public string PhoneNumber => Phone.Phone;

    public string ProfilePhoto => Photo.Photo;
}