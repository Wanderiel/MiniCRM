using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DbModels
{
    public class UserDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(255)]
        public string Email { get; set; }
        [Required, StringLength(255)]
        public string PasswordHash { get; set; }
        [Required, StringLength(100)]
        public string FirstName { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }
        [AllowNull, StringLength(500)]
        public string? AvatarUrl { get; set; } = null!;
        [Required, Timestamp]
        public DateTime CreatedAt { get; set; }
        [Required, Timestamp]
        public DateTime UpdatedAt { get; set; }
    }
}
