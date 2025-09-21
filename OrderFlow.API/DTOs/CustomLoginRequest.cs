namespace OrderFlow.API.DTOs
{
    public class CustomLoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
