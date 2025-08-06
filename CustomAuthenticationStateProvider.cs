using Excellentiam.Data.UnitOfWork.Interface;
using Excellentiam.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _jsRuntime;

    public CustomAuthenticationStateProvider(
        IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;

    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var usuarioData = await UsuarioData();
            var identity = new ClaimsIdentity();
            if (usuarioData != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuarioData.Nombre),
                    new Claim(ClaimTypes.NameIdentifier, usuarioData.Id.ToString())
                }, "SessionAuth");
            }
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    public async Task NotifyUserAuthentication()
    {
        var authState = await GetAuthenticationStateAsync();
        Console.WriteLine(authState);
        NotifyAuthenticationStateChanged(Task.FromResult(authState));
    }

    public void NotifyUserLogout()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public async Task<UsuarioData> UsuarioData()
    {
        var json = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authUser");
        return JsonSerializer.Deserialize<UsuarioData>(json);
    }
}