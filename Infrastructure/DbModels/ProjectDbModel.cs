using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DbModels
{
    public class ProjectDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [AllowNull]
        public string? Description { get; set; } = null!;
        [AllowNull]
        public DateOnly? StartDate { get; set; } = null!;
        [AllowNull]
        public DateOnly? EndDate { get; set; } = null!;
        [Required, StringLength(50)]
        public string Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public List<TaskItemDbModel>? Tasks { get; set; }
    }
}
