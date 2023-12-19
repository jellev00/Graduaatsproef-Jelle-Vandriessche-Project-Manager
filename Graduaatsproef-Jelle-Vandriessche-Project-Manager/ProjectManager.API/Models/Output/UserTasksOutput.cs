using ProjectManager.BL.Models;

namespace ProjectManager.API.Models.Output
{
    public class UserTasksOutput
    {
        public UserTasksOutput(int taskId, string taskName, string taskDescription, string color, DateTime date, bool status)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            Color = color;
            Date = date;
            Status = status;
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
