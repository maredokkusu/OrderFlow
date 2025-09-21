using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderFlow.API.Data;
using OrderFlow.API.Models;
using OrderFlow.API.Services.Interfaces;

namespace OrderFlow.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(ApplicationDbContext context, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<string?> RegisterAsync(string Email, string Password, string UserName)
        {
            if (_context.Customers.Any(
                c => c.Email == Email)){
                return null;
            }
            var customer = new Customer
            {
                Email = Email,
                PassWordHash = BCrypt.Net.BCrypt.HashPassword(Password),
                UserName = UserName,

            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var token = _jwtTokenService.GenerateToken(customer.Email,customer.UserId.ToString(), customer.Email, customer.Role);
            return token;
            }
        public async Task<string?> LoginAsync(string Email, string Password) {
            var customer = await _context.Customers.FirstOrDefaultAsync(
                c => c.Email == Email);
            if (customer == null || !BCrypt.Net.BCrypt.Verify(Password, customer.PassWordHash)) {
                return null;
            }
            return _jwtTokenService.GenerateToken(customer.Email,customer.UserId.ToString(), customer.Email,customer.Role);
        } 
    } 
}
