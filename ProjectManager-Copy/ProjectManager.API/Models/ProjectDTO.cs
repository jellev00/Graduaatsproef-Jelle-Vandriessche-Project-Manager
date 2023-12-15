using System.Xml.Linq;

namespace ProjectManager.API.Models
{
    public class ProjectDTO
    {
        public ProjectDTO(int userId, string name, string description, string color)
        {
            UserId = userId;
            Name = name;
            Description = description;
            Color = color;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
