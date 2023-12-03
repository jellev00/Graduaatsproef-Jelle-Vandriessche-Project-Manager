namespace ProjectManager.API.Models
{
    public class UserTasksDTO
    {
        public UserTasksDTO(int userId, string taskName, string taskDescription, string color)
        {
            UserId = userId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            Color = color;
        }

        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Color { get; set; }
    }
}
