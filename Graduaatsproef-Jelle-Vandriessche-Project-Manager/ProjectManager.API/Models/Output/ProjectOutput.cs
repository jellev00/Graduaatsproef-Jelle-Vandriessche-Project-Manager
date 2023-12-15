using ProjectManager.BL.Models;

namespace ProjectManager.API.Models.Output
{
    public class ProjectOutput
    {
        public ProjectOutput(int projectId, string name, string description, string color)
        {
            ProjectId = projectId;
            Name = name;
            Description = description;
            Color = color;
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
