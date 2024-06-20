using Backend.Donation.Domain.Model.Commnads.Ong;
using Backend.Donation.Interfaces.REST.Resources;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Interfaces.REST.Transform;

public class CreateOngCommandFromResourceAssembler
{
    public static CreateOngCommand ToCommandFromResource(CreateOngResource resource)
    {
        return new CreateOngCommand(
            resource.Name,
            resource.Type,
            resource.AboutUs,
            resource.MissionVision,
            resource.SupportForm,
            resource.Address,
            resource.Email,
            resource.Number,
            resource.UrlLogo,
            resource.UrlWebSite,
            resource.AttentionSchedule,
            resource.CategoryId
            );
    }
}