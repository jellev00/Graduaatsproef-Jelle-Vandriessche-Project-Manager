namespace ProjectManager.API.Models
{
    public class ProjectTasksDTO
    {
        public ProjectTasksDTO(int projectId, string taskName, string taskDescription, string color)
        {
            ProjectId = projectId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            Color = color;
        }

        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Color { get; set; }
    }
}
