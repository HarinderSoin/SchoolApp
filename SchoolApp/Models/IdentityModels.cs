using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<ClassAllocation> ClassAllocations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<ClassPeriod> ClassPeriods { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StudentUser> StudentUsers { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAssignment> TeachersAssignments { get; set; }

        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<StudentAssessment> StudentAssessments { get; set; }
        public DbSet<AssessmentGrades> AssessmentGrades { get; set; }

        /*
        public DbSet<TeacherNote> TeachersNotes{ get; set; }
        */
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherNote>()
                        .HasRequired(t => t.Teacher)
                        .WithMany()
                        .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
        */
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}