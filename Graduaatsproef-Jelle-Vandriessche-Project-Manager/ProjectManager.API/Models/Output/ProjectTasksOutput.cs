﻿namespace ProjectManager.API.Models.Output
{
    public class ProjectTasksOutput
    {
        public ProjectTasksOutput(int taskId, string taskName, string taskDescription, string color, DateTime date)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            Color = color;
            Date = date;
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }
    }
}
