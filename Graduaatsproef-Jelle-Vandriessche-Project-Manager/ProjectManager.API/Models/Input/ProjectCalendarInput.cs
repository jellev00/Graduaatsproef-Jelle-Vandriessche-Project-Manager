namespace ProjectManager.API.Models.Input
{
    public class ProjectCalendarInput
    {
        public ProjectCalendarInput(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
