using AcademicCoursesCRUD.BL;
using AcademicCoursesCRUD.Common;
using AcademicCoursesCRUD.DTO;
using AcademicCoursesCRUD.Interfaces;
using AcademicCoursesCRUD.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicCoursesCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcademicCoursesController : ControllerBase
    {
        private AcademicCourseBLL AcademicCourseBLL=null;

        private readonly ILogger<AcademicCoursesController> _logger;

        public AcademicCoursesController(ILogger<AcademicCoursesController> logger)
        {
            AcademicCourseBLL = new AcademicCourseBLL();
            _logger = logger;
        }

        [HttpPost("AddCourse")]
        
        public  async Task<AcademicCourse> AddAcCourse([FromBody] AcademicCourseDTO academicCourseDTO)
            {
/*            AcademicCourseDTO academicCourseDTO = new AcademicCourseDTO();
*/

            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status  
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await AcademicCourseBLL.AddAcCourse(academicCourseDTO);
        }
        [HttpGet("GetCourses")]
        public async Task<List<AcademicCourseDTO>> GetAllCourses()
        {
            /*            AcademicCourseDTO academicCourseDTO = new AcademicCourseDTO();
            */

            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await AcademicCourseBLL.GetAcCourss();
        }
        [HttpGet("GetCourseById")]

        public async Task<AcademicCourseDTO> GetCoursedById (int courseId )
        {
          
            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await AcademicCourseBLL.GetCourseById(courseId);
        }
        [HttpPost("UpdateCourse")]
        public async Task<AcademicCourseDTO> UpdateCourse([FromBody] AcademicCourseDTO course)
         {
            
            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await AcademicCourseBLL.UpdateCourse(course);
        }

        [HttpPost("DeleteCourse")]
        public async Task<AcademicCourseDTO> DeleteCourse([FromBody] AcademicCourseDTO course)
        {
           
            GenaricResponse<int> response = new GenaricResponse<int>();
            Status status = new Status
            {
                Errors = null,
                Reason = "",
                StatusCode = 200
            };
            response.status = status;
            return await AcademicCourseBLL.DeleteCourse(course.CourseId);
        }
    }
}
