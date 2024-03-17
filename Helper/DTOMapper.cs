using AutoMapper;
using AcademicCoursesCRUD.DTO;
using AcademicCoursesCRUD.Models;


namespace AcademicCoursesCRUD.Helper
{
    public class DTOMapper : Profile
    {
        public static IMapper mapper { get; set; }
        static DTOMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AcademicCourseDTO, AcademicCourse>().ForMember(O=>O.CourseCredit,opt=>opt.Ignore()).ForMember(o=>o.CourseDescription,opt=>opt.Ignore())
                .ForMember(o=>o.AcademicCourses,opt=>opt.Ignore()).ForMember(o=>o.CourseId,opt=>opt.Ignore()).ReverseMap()  ;
           });
            configuration.AssertConfigurationIsValid();
            mapper = configuration.CreateMapper();
        }
    }
}
