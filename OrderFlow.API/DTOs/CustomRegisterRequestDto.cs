using System.Runtime.CompilerServices;

namespace OrderFlow.API.DTOs
{
    public class CustomRegisterRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }=string.Empty;
        public string UserName { get; set; }=string.Empty;
            

        
    }
}
