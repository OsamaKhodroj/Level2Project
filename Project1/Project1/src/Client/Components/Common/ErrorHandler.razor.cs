﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using Project1.Client.Infrastructure.Auth;

namespace Project1.Client.Components.Common;
public partial class ErrorHandler
{
    [Inject]
    public IAuthenticationService AuthService { get; set; } = default!;

    public List<Exception> _receivedExceptions = new();

    protected override async Task OnErrorAsync(Exception exception)
    {
        _receivedExceptions.Add(exception);
        switch (exception)
        {
            case UnauthorizedAccessException:
                await AuthService.LogoutAsync();
                Snackbar.Add("Authentication Failed", Severity.Error);
                break;
        }
    }

    public new void Recover()
    {
        _receivedExceptions.Clear();
        base.Recover();
    }
}