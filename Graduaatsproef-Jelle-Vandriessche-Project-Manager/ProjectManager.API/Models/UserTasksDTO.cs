namespace ProjectManager.API.Models
{
    public class UserTasksDTO
    {
        public UserTasksDTO(int userId, string taskDescription)
        {
            UserId = userId;
            TaskDescription = taskDescription;
        }

        public int UserId { get; set; }
        public string TaskDescription { get; set; }
    }
}
