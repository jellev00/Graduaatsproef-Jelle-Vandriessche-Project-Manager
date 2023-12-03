using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Models;
using ProjectManager.BL.Managers;
using ProjectManager.BL.Models;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCalendarController : ControllerBase
    {
        private ProjectCalendarManager _ProjectCalendarManager;
        private ProjectManager.BL.Managers.ProjectManager _projectManager;

        public ProjectCalendarController(ProjectCalendarManager projectCalendarManager, BL.Managers.ProjectManager projectManager)
        {
            _ProjectCalendarManager = projectCalendarManager;
            _projectManager = projectManager;
        }

        [HttpGet("~/api/Project/{ProjectID}/[controller]")]
        public ActionResult<List<ProjectCalendar>> GetCalendarByProjectID(int ProjectID)
        {
            try
            {
                if (_projectManager.ProjectExists(ProjectID))
                {
                    List<ProjectCalendar> projectCalendar = _ProjectCalendarManager.GetAllProjectCalendars(ProjectID);
                    return Ok(projectCalendar);
                }

                return NotFound($"Project with ID {ProjectID} not found.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProjectCalendarDTO> AddCalendar([FromBody] ProjectCalendarDTO projectCalendarDTO)
        {
            try
            {
                var projectCalendar = new ProjectCalendar(projectCalendarDTO.ProjectId, projectCalendarDTO.Name, projectCalendarDTO.Description, projectCalendarDTO.Date);
                _ProjectCalendarManager.AddCalendar(projectCalendar);

                var createdCalendarDTO = new ProjectCalendarDTO(projectCalendar.ProjectId, projectCalendar.Name, projectCalendar.Description, projectCalendar.Date);

                return CreatedAtAction(nameof(GetCalendarByProjectID), new { ProjectId = projectCalendar.ProjectId }, createdCalendarDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{calendarID}")]
        public ActionResult DeleteCalendar(int calendarID)
        {
            try
            {
                if (!_ProjectCalendarManager.CalendarExists(calendarID))
                {
                    return NotFound();
                }
                else
                {
                    _ProjectCalendarManager.DeleteCalendar(calendarID);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
