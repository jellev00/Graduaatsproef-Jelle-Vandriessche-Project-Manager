using ProjectManager.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Exceptions;

namespace ProjectManager.BL.Models
{
    public class ProjectCalendar
    {
        public ProjectCalendar(int calendarId, Project project, string name, string description, DateTime date)
        {
            _calendarId = calendarId;
            _project = project;
            _name = name;
            _Description = description;
            _date = date;
        }

        public ProjectCalendar(Project project, string name, string description, DateTime date)
        {
            _name = name;
            _Description = description;
            _date = date;
        }

        private int _calendarId;
        public int CalendarId
        {
            get
            {
                return _calendarId;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ProjectCalendarException("ID is invalid!");
                }
                else
                {
                    _calendarId = value;
                }
            }
        }

        private Project _project;
        public Project Project
        {
            get
            {
                return _project;
            }
            set
            {
                if (value == null)
                {
                    throw new ProjectCalendarException("Project is invalid!");
                }
                else
                {
                    _project = value;
                }
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new UserException("Name is invalid!");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ProjectCalendarException("Description is invalid!");
                }
                else
                {
                    _Description = value;
                }
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ProjectCalendarException("Date is invalid!");
                } else
                {
                    _date = value;
                }
            }
        }
    }
}
