using Excellentiam.Data.UnitOfWork.Interface;
using Excellentiam.DTOs;
using Excellentiam.Models;
using Excellentiam.Service.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;
namespace Excellentiam.Service.Impl;

public class AutenticacionService : IAutenticacionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly IJSRuntime _jsruntime;

    public AutenticacionService(
        IUnitOfWork unitOfWork,
        IPasswordHasher<Usuario> passwordHasher,
        IJSRuntime jSRuntime)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jsruntime = jSRuntime;
    }
    public async Task<bool> LoginAsync(LoginDTO login)
    {
        var usuario = await _unitOfWork.Usuario
            .GetFirstOrDefaultAsync(filter:u => u.Correo == login.Correo);

        if (usuario == null) return false;

        var verificacionContraseña =_passwordHasher
            .VerifyHashedPassword(usuario, usuario.Contraseña, login.Contraseña);

        if(verificacionContraseña != PasswordVerificationResult.Success)
            return false;

        var userDatos = new UsuarioData
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre
        };

        await _jsruntime.InvokeVoidAsync("sessionStorage.setItem", "authUser", JsonSerializer.Serialize(userDatos));

        return true;
    }

    public async Task<bool> RegisterAsync(RegisterDTO register)
    {
        var usuario = await _unitOfWork.Usuario.GetFirstOrDefaultAsync(filter: u => u.Correo == register.Correo);
        
        if(usuario != null) return false;

        Usuario nuevoUsuario = new()
        {
            Nombre = register.Nombre,
            Correo = register.Correo,
        };

        var contraseñaHash = _passwordHasher.HashPassword(nuevoUsuario, register.Contraseña);
        nuevoUsuario.Contraseña = contraseñaHash;
        await _unitOfWork.Usuario.AddAsync(nuevoUsuario);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task LogoutAsync()
    {
        await _jsruntime.InvokeVoidAsync("sessionStorage.removeItem", "authUser");
    }


}
