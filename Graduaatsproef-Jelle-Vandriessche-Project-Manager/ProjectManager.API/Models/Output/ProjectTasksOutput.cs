namespace ProjectManager.API.Models.Output
{
    public class ProjectTasksOutput
    {
        public ProjectTasksOutput(int taskId, string taskName, string taskDescription, string color)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            Color = color;
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Color { get; set; }
    }
}
