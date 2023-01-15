﻿using API.Domain.Common;

namespace API.Domain;

public sealed class Contact
{
    public required FirstName FirstName { get; init; }
    public required LastName LastName { get; init; }
    public required Email Email { get; init; }
    public required Message Message { get; init; }
    public required DateTime CreatedAt { get; init; }
}