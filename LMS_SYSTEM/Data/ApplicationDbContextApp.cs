using LMS_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS_SYSTEM.Data
{
    public class ApplicationDbContextApp : DbContext
    {
        public virtual DbSet<lessons> lessons { get; set; }
        public virtual DbSet<teacher_to_lesson> teacher_to_lesson { get; set; }
        public virtual DbSet<school_work> school_work { get; set; }
        public virtual DbSet<student_to_work> student_to_work { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<users_authority> users_authority { get; set; }

        public ApplicationDbContextApp(DbContextOptions<ApplicationDbContextApp> options) : base(options) { }
    }
}
