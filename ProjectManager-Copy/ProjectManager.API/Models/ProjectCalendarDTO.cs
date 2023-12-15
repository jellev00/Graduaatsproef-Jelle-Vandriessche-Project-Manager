namespace ProjectManager.API.Models
{
    public class ProjectCalendarDTO
    {
        public ProjectCalendarDTO(int projectId, string name, string description, DateTime date)
        {
            ProjectId = projectId;
            Name = name;
            Description = description;
            Date = date;
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
