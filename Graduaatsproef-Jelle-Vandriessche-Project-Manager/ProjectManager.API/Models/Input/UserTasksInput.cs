using ProjectManager.BL.Models;

namespace ProjectManager.API.Models.Input
{
    public class UserTasksInput
    {
        public UserTasksInput(string taskName, string taskDescription, string color)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            Color = color;
        }

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Color { get; set; }
    }
}
