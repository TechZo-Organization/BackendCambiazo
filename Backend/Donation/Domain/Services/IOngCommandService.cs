using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.Ong;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Domain.Services;

public interface IOngCommandService
{
    Task<Ong> Handle(CreateOngCommand command);
    Task<Ong> Handle(UpdateOngCommand command);
    Task<Ong> Handle(DeleteOngCommand command);
}