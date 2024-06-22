using Backend.Donation.Domain.Model.Commnads.SocialNetwork;

namespace Backend.Donation.Domain.Model.Aggregates;

public class SocialNetwork
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public int OngId { get; set; }
    
    public Ong Ong { get; set; }

    
    public SocialNetwork(string name, string url, string icon, int ongId)
    {
        Name = name;
        Url = url;
        Icon = icon;
        OngId = ongId;
    }
    
    public SocialNetwork()
    {
    }
    
    public SocialNetwork(CreateSocialNetworkCommand command)
    {
        Name = command.Name;
        Url = command.Url;
        Icon = command.Icon;
        OngId = command.OngId;
    }
    
    public void Update(UpdateSocialNetworkCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Url = command.Url;
        Icon = command.Icon;
        OngId = command.OngId;
    }
}