using System.ComponentModel.DataAnnotations;

namespace OrderFlow.API.Models
{
    public class Customer
    {
        [Key] 
        public Guid UserId { get; set; }= Guid.NewGuid();
        [Required]
        public string UserName { get; set; }=string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PassWordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer";
    }
}
