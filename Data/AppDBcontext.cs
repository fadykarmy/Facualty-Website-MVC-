using Microsoft.EntityFrameworkCore;
using The_project.model;
namespace The_project.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Coliseum> Coliseums { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<RegisterViewModel> RegisterViewModels { get; set; }
        public DbSet<The_project.model.User>? User { get; set; }
        public DbSet<StudentCreative> StudentCreative { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RegisterAdmin> RegisterAdmins { get; set; }




    }
}