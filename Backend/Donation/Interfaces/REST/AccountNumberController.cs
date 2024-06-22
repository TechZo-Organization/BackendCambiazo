using Backend.Donation.Domain.Model.Commnads.AccountNumber;
using Backend.Donation.Domain.Services;
using Backend.Donation.Interfaces.REST.Resources.AccountNumber;
using Backend.Donation.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Donation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountNumberController(IAccountNumberCommandService accountNumberCommandService) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAccountNumber(CreateAccountNumberResource resource)
    {
        var createAccountNumberCommand = CreateAccountNumberCommandFromResourceAssembler.ToCommandFromResource(resource);
        var accountNumber = await accountNumberCommandService.Handle(createAccountNumberCommand);
        if (accountNumber is null) return BadRequest();
        var accountNumberResource = ResourceAccountNumberFromEntityAssembler.ToResourceFromEntity(accountNumber);
        //return CreatedAtAction(nameof(GetAccountNumberById), new {accountNumberId = accountNumberResource.Id}, accountNumberResource);
        return Ok(accountNumberResource);
    }
    
    [HttpPut]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateAccountNumber(int accountNumberId, CreateAccountNumberResource resource)
    {
        var updateAccountNumberCommand = new UpdateAccountNumberCommand(accountNumberId, resource.Name, resource.CCI, resource.Number, resource.OngId);
        var accountNumber = await accountNumberCommandService.Handle(updateAccountNumberCommand);
        if (accountNumber == null) return NotFound();
        var accountNumberResource = ResourceAccountNumberFromEntityAssembler.ToResourceFromEntity(accountNumber);
        return Ok(accountNumberResource);
    }
    
    [HttpDelete("{accountNumberId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteAccountNumber(int accountNumberId)
    {
        var deleteAccountNumberCommand = new DeleteAccountNumberCommand(accountNumberId);
        var accountNumber = await accountNumberCommandService.Handle(deleteAccountNumberCommand);
        if (accountNumber == null) return NotFound();
        var accountNumberResource = ResourceAccountNumberFromEntityAssembler.ToResourceFromEntity(accountNumber);
        return Ok(accountNumberResource);
    }
}