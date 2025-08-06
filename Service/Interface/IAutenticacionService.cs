using Excellentiam.DTOs;

namespace Excellentiam.Service.Interface;

public interface IAutenticacionService
{
    Task<bool> LoginAsync(LoginDTO login);
    Task<bool> RegisterAsync(RegisterDTO register);
    Task LogoutAsync();
}
