using Backend.Profiles.Domain.Model.Commands.BenefitCommands;
using Backend.Profiles.Domain.Model.Entities;

namespace Backend.Profiles.Domain.Model.Aggregates;

public class Benefit
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int MembershipId { get; set; }
    
    public Membership Membership { internal get;  set; }
    
    public Benefit()
    {
        
    }
    
    public Benefit(string description, int membershipId)
    {
        Description = description;
        MembershipId = membershipId;
    }
    
    public Benefit(CreateBenefitCommand command)
    {
        Description = command.Description;
        MembershipId = command.MembershipId;
       
    }

    public void Update(UpdateBenefitCommand command)
    {
        Description = command.Description;
        MembershipId = command.MembershipId;
        
    }
 
    
    
    
}