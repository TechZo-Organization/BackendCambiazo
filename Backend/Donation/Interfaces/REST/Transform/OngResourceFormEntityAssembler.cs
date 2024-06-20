using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Interfaces.REST.Resources;

namespace Backend.Donation.Interfaces.REST.Transform;


public class OngResourceFormEntityAssembler
{
    public static OngResource ToResourceFromEntiry(Ong ong)
    {
        return new OngResource(
            ong.Id,
            ong.Name,
            ong.Type,
            ong.AboutUs,
            ong.MissionVision,
            ong.SupportForm,
            ong.Address,
            ong.Email,
            ong.Number,
            ong.UrlLogo,
            ong.UrlWebSite,
            ong.AttentionSchedule,
            ong.Projects,
            ong.SocialNetworks,
            ong.AccountNumbers,
            ong.Category
        );
    }
}