using AcademicCoursesCRUD.Common;
using AcademicCoursesCRUD.DTO;
using AcademicCoursesCRUD.Helper;
using AcademicCoursesCRUD.Interfaces;
using AcademicCoursesCRUD.Models;
using AcademicCoursesCRUD.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicCoursesCRUD.BL
{
    public class AcademicCourseBLL : DTOMapper
    {
        private IAcademicCourseRepository repository = null;
        private readonly IConfiguration _configuration;
        public AcademicCourseBLL()
        {

            this.repository = new AcademicCoursesRepository( );
        }

        public async Task<AcademicCourse> AddAcCourse(AcademicCourseDTO academicCourseDTO )
        {
            var obj = DTOMapper.mapper.Map<AcademicCourse>(academicCourseDTO);

            return await repository.AddacCourse(obj);
           

        }
        public async Task<List<AcademicCourseDTO>> GetAcCourss()
        {
            var academicCourse = await repository.GetAllCourses();

            var objDTO = DTOMapper.mapper.Map<List<AcademicCourseDTO>>(academicCourse);
            return objDTO;
        }

        public async Task<AcademicCourseDTO> GetCourseById(int courseId)
        {
            var academicCourse = await repository.GetCourseById(courseId);

            var objDTO = DTOMapper.mapper.Map<AcademicCourseDTO>(academicCourse);
            return objDTO;
        }
        public async Task<AcademicCourseDTO> UpdateCourse(AcademicCourseDTO academicCourseDTO )
        {
            int id = academicCourseDTO.CourseId;
            var obj = DTOMapper.mapper.Map<AcademicCourse>(academicCourseDTO);

            var academicCourse = await repository.UpdateCourse(obj,id);

            var objDTO = DTOMapper.mapper.Map<AcademicCourseDTO>(academicCourse);
            return objDTO;
        }

        public async Task<AcademicCourseDTO> DeleteCourse(int courseId)
        {
            var academicCourse = await repository.DeleteCourse(courseId);

            var objDTO = DTOMapper.mapper.Map<AcademicCourseDTO>(academicCourse);
            return objDTO;
        }
    }
}

