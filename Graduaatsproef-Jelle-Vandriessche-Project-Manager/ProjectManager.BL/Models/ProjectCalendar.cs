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
        public ProjectCalendar(int projectId, string name, string description, DateTime date)
        {
            _projectId = projectId;
            _name = name;
            _Description = description;
            _date = date;
        }

        public ProjectCalendar(int calendarId, int projectId, string name, string description, DateTime date)
        {
            _calendarId = calendarId;
            _projectId = projectId;
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

        private int _projectId;
        public int ProjectId
        {
            get
            {
                return _projectId;
            }
            set
            {
                _projectId = value;
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
