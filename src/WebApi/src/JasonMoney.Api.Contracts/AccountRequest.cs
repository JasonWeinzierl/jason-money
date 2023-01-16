namespace JasonMoney.Api.Contracts;

public record AccountRequest(string Name, string? Description, string? BankSwift, string? ExternalId);
