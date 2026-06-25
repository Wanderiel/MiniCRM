namespace Application.Dtos.Projects
{
    public class CreatedProjectDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public required string Status { get; set; }
    }
}
