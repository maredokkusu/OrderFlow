namespace OrderFlow.API.Services.Interfaces
{
    public interface IJwtTokenService
    {
     string GenerateToken(string email,string userId, string userName, string role);
 
    }
}
