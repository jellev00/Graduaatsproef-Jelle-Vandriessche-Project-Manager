namespace ProjectManager.API.Models.Input
{
    public class ProjectInput
    {
        public ProjectInput(string name, string description, string color)
        {
            Name = name;
            Description = description;
            Color = color;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
