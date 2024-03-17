using System.Collections.Generic;
using System.Reflection;

namespace AcademicCoursesCRUD.Models
{
    public partial class AcademicCourse
    {
        public AcademicCourse()
        {
        }

        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string? CourseDescription { get; set; }
        
         public string CourseName { get; set; }
        public string? CourseCredit { get; set; }

        public virtual AcademicCourse AcademicCourses { get; set; }
    }
}
