﻿using FSH.WebApi.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace Project1.Client.Infrastructure.Auth;
public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource) =>
        Policy = FSHPermission.NameFor(action, resource);
}