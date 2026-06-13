using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DbModels
{
    public class TaskItemDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public ProjectDbModel Project { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        [AllowNull]
        public string? Desctiption { get; set; } = null!;
        [ForeignKey(nameof(UserDbModel)), Required]
        public int CreatedById { get; set; }
        [ForeignKey(nameof(UserDbModel)), Required]
        public int AssignedToId { get; set; }
        [AllowNull]
        public DateOnly? DueDate { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
