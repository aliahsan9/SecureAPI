
using Microsoft.AspNetCore.Identity;

namespace SecureAPI.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLoginAt { get; set; }

        // Navigation properties
        public ICollection<RefreshToken>? RefreshTokens { get; set; }


    }
}
