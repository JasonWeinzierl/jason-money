using JasonMoney.Api.Contracts;
using JasonMoney.Domain.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace JasonMoney.Api.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;

    public AccountsController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    /// <summary>
    /// Gets all open accounts.
    /// </summary>
    [HttpGet("")]
    public async Task<IEnumerable<AccountResponse>> GetAll(CancellationToken cancellationToken)
        => (await _accountRepository.GetAll(cancellationToken)).Select(x => new AccountResponse(x.Uid, x.Name, x.Description, x.BankSwift, x.ExternalId, x.Group is not null ? new AccountGroupResponse(x.Group.Uid, x.Group.Name) : null));

    /// <summary>
    /// Gets an account by UID.
    /// </summary>
    [HttpGet("{uid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccountResponse>> GetByUid(Guid uid, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByUid(uid, cancellationToken);
        if (account is null) return NotFound();
        else return Ok(new AccountResponse(account.Uid, account.Name, account.Description, account.BankSwift, account.ExternalId, account.Group is not null ? new AccountGroupResponse(account.Group.Uid, account.Group.Name) : null));
    }

    /// <summary>
    /// Creates a new account.
    /// </summary>
    [HttpPost("")]
    public async Task<ActionResult<AccountResponse>> Create(AccountRequest request, CancellationToken cancellationToken)
    {
        var account = new Account(Guid.NewGuid(), request.Name, request.Description, request.BankSwift, request.ExternalId, null);
        account = await _accountRepository.Insert(account, cancellationToken);
        return CreatedAtAction(nameof(GetByUid), new { uid = account.Uid }, account);
    }

    /// <summary>
    /// Updates an account.
    /// </summary>
    [HttpPut("{uid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccountResponse>> Update(Guid uid, AccountRequest request, CancellationToken cancellationToken)
    {
        var account = new Account(uid, request.Name, request.Description, request.BankSwift, request.ExternalId, null);
        account = await _accountRepository.Update(account, cancellationToken);
        if (account is null) return NotFound();
        else return Ok(account);
    }

    /// <summary>
    /// Deletes an account.
    /// </summary>
    [HttpDelete("{uid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid uid, CancellationToken cancellationToken)
    {
        await _accountRepository.Delete(uid, DateTimeOffset.Now, cancellationToken);
        return NoContent();
    }
}
