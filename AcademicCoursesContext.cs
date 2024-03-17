namespace AcademicCoursesCRUD
{
    
    using global::AcademicCoursesCRUD.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    namespace AcademicCoursesCRUD.EntityModel
    {
        public partial class AcademicCoursesContext : DbContext 
        {
            public AcademicCoursesContext()
            {
            }

            public AcademicCoursesContext(DbContextOptions<AcademicCoursesContext> options)
                : base(options)
            {
            }

            public virtual DbSet<AcademicCourse> AcademicCourses { get; set; }

           
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer ("Server=Hady-Sharawi\\SQLEXPRESS;Database=AcCourses;Trusted_Connection=True;MultipleActiveResultSets=true");
                }
            }
            

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
      
                modelBuilder.Entity<AcademicCourse>(entity =>
                {
                    entity.HasKey(e => e.CourseId);

                    entity.ToTable("Academic_Courses");

                    entity.Property(e => e.CourseId).HasColumnName("Course_ID");

                    entity.Property(e => e.CourseCode).HasColumnName("Course_Code");

                    entity.Property(e => e.CourseCredit).HasColumnName("Course_Credit");
/*
                    entity.HasOne(d => d.Apclaim)
                        .WithMany(p => p.ApFiles)
                        .HasForeignKey(d => d.ApclaimId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AP_Files_APClaims");

                    entity.HasOne(d => d.File)
                        .WithMany(p => p.ApFiles)
                        .HasForeignKey(d => d.FileId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AP_Files_UploadedFiles");*/
                });

           
      

                OnModelCreatingPartial(modelBuilder);
            }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
    }

}
