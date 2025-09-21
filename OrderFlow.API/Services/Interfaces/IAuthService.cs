using OrderFlow.API.Models;

namespace OrderFlow.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(string Email,string Password,string UserName);

    Task<string?>LoginAsync(string Email,string Password);
    }
}
