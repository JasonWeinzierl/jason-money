using System;

namespace JasonMoney.Domain.Categories;

public record Category(
    Guid Uid,
    string Name,
    string? Subname);
