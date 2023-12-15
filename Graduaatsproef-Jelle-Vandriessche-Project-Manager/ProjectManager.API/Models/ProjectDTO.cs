using ProjectManager.BL.Models;
using System.Xml.Linq;

namespace ProjectManager.API.Models
{
    public class ProjectDTO
    {
        public ProjectDTO(User user, string name, string description, string color)
        {
            User = user;
            Name = name;
            Description = description;
            Color = color;
        }

        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
