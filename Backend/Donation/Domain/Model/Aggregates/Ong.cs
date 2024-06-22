using System.Text.Json.Serialization;
using Backend.Donation.Domain.Model.Commnads.Ong;
using Backend.Donation.Domain.Model.Enitities;
using Backend.Donation.Domain.Model.Commnads;
using Backend.Donation.Interfaces.REST.Resources;
using Backend.Donation.Interfaces.REST.Transform;

namespace Backend.Donation.Domain.Model.Aggregates;

public class Ong
{
    public int Id {get;set;}
    public string Name {get;set;}   
    public string Type {get;set;}
    public string AboutUs {get;set;}
    public string MissionVision {get;set;}
    public string SupportForm {get;set;}
    public string Address {get;set;}
    public string Email {get;set;}
    public string Number {get;set;}
    public string UrlLogo {get;set;}
    public string UrlWebSite {get;set;}
    public string AttentionSchedule { get; set; }

    public int CategoryId {get;set;}
    [JsonIgnore]
    public ICollection<Project> Projects { get; internal set; }
    [JsonIgnore]
    public ICollection<SocialNetwork> SocialNetworks { get;internal set; }
    [JsonIgnore]
    public ICollection<AccountNumber> AccountNumbers { get;internal set; }

    public Category Category {get;internal set;}
    
    
    public Ong( string name, string type, string aboutUs, string missionVision, string supportForm, string address, string email, string number, string urlLogo, string urlWebSite, string attentionSchedule,int categoryId)
    {
        Name = name;
        Type = type;
        AboutUs = aboutUs;
        MissionVision = missionVision;
        SupportForm = supportForm;
        Address = address;
        Email = email;
        Number = number;
        UrlLogo = urlLogo;
        UrlWebSite = urlWebSite;
        AttentionSchedule = attentionSchedule;
        CategoryId = categoryId;
    }
    
    public Ong(){}

    public Ong(CreateOngCommand command)
    {
        Name = command.Name;
        Type = command.Type;
        AboutUs = command.AboutUs;
        MissionVision = command.MissionVision;
        SupportForm = command.SupportForm;
        Address = command.Address;
        Email = command.Email;
        Number = command.Number;
        UrlLogo = command.UrlLogo;
        UrlWebSite = command.UrlWebSite;
        AttentionSchedule = command.AttentionSchedule;
        CategoryId = command.CategoryId;
    }

    public void Update(UpdateOngCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Type = command.Type;
        AboutUs = command.AboutUs;
        MissionVision = command.MissionVision;
        SupportForm = command.SupportForm;
        Address = command.Address;
        Email = command.Email;
        Number = command.Number;
        UrlLogo = command.UrlLogo;
        UrlWebSite = command.UrlWebSite;
        AttentionSchedule = command.AttentionSchedule;
        CategoryId = command.CategoryId;
    }
}