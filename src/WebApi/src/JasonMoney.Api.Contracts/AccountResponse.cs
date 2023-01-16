namespace JasonMoney.Api.Contracts;

public record AccountResponse(Guid Uid, string Name, string? Description, string? BankSwift, string? ExternalId, AccountGroupResponse? Group);
