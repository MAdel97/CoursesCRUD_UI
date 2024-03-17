using AcademicCoursesCRUD.DTO;
using AcademicCoursesCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicCoursesCRUD.Interfaces
{
    public interface IAcademicCourseRepository
    {
        Task<AcademicCourse> AddacCourse(AcademicCourse _obj);
        Task<List<AcademicCourse>> GetAllCourses();
        Task<AcademicCourse> GetCourseById(int id);
        Task<AcademicCourse> UpdateCourse(AcademicCourse course,int id);
        Task<AcademicCourse> DeleteCourse(int courseId);


    }
}
