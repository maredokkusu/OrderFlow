﻿namespace OrderFlow.API.DTOs
{
    public class AuthResponseDto
    {
        public int UserId   { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;

        public string UserName { get; set; }= string.Empty;
        
        
    }
}
