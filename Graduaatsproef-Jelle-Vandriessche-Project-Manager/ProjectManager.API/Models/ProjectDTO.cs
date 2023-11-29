using System.Xml.Linq;

namespace ProjectManager.API.Models
{
    public class ProjectDTO
    {
        public ProjectDTO(int userId, string name, string description)
        {
            UserId = userId;
            Name = name;
            Description = description;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
