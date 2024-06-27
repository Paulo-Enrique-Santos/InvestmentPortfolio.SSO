using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolio.SSO.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}