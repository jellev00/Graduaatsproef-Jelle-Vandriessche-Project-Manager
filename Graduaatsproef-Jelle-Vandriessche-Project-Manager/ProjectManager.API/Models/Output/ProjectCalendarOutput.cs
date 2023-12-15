namespace ProjectManager.API.Models.Output
{
    public class ProjectCalendarOutput
    {
        public ProjectCalendarOutput(int calendarId, string name, string description, DateTime date)
        {
            CalendarId = calendarId;
            Name = name;
            Description = description;
            Date = date;
        }

        public int CalendarId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
