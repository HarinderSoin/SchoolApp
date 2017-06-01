namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAcademicYearToTeacherAssignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassAllocations", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.ClassAllocations", "ClassPeriodID", "dbo.ClassPeriods");
            DropForeignKey("dbo.ClassAllocations", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.ClassAllocations", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.ClassAllocations", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Parents", "StateID", "dbo.States");
            DropForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.StudentAssessments", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.StudentAssessments", "AssessmentGradesID", "dbo.AssessmentGrades");
            DropForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.StudentAssessments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Students", "ParentID", "dbo.Parents");
            DropForeignKey("dbo.StudentAssignments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssignments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.StudentUsers", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Teachers", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.TeacherAssignments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.TeacherAssignments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.TeacherAssignments", "TeacherID", "dbo.Teachers");
            AddColumn("dbo.TeacherAssignments", "AcademicYearID", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.TeacherAssignments", "AcademicYearID");
            AddForeignKey("dbo.TeacherAssignments", "AcademicYearID", "dbo.AcademicYears", "ID");
            AddForeignKey("dbo.ClassAllocations", "AcademicYearID", "dbo.AcademicYears", "ID");
            AddForeignKey("dbo.ClassAllocations", "ClassPeriodID", "dbo.ClassPeriods", "ID");
            AddForeignKey("dbo.ClassAllocations", "GradeID", "dbo.Grades", "ID");
            AddForeignKey("dbo.ClassAllocations", "RoomID", "dbo.Rooms", "ID");
            AddForeignKey("dbo.ClassAllocations", "SubjectID", "dbo.Subjects", "ID");
            AddForeignKey("dbo.Parents", "StateID", "dbo.States", "ID");
            AddForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.StudentAssessments", "AcademicYearID", "dbo.AcademicYears", "ID");
            AddForeignKey("dbo.StudentAssessments", "AssessmentGradesID", "dbo.AssessmentGrades", "ID");
            AddForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades", "ID");
            AddForeignKey("dbo.StudentAssessments", "StudentID", "dbo.Students", "ID");
            AddForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects", "ID");
            AddForeignKey("dbo.Students", "ParentID", "dbo.Parents", "ID");
            AddForeignKey("dbo.StudentAssignments", "GradeID", "dbo.Grades", "ID");
            AddForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students", "ID");
            AddForeignKey("dbo.StudentAssignments", "SubjectID", "dbo.Subjects", "ID");
            AddForeignKey("dbo.StudentUsers", "StudentID", "dbo.Students", "ID");
            AddForeignKey("dbo.Teachers", "AcademicYearID", "dbo.AcademicYears", "ID");
            AddForeignKey("dbo.TeacherAssignments", "GradeID", "dbo.Grades", "ID");
            AddForeignKey("dbo.TeacherAssignments", "SubjectID", "dbo.Subjects", "ID");
            AddForeignKey("dbo.TeacherAssignments", "TeacherID", "dbo.Teachers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherAssignments", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAssignments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.TeacherAssignments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.Teachers", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.StudentUsers", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssignments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssignments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.Students", "ParentID", "dbo.Parents");
            DropForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.StudentAssessments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.StudentAssessments", "AssessmentGradesID", "dbo.AssessmentGrades");
            DropForeignKey("dbo.StudentAssessments", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parents", "StateID", "dbo.States");
            DropForeignKey("dbo.ClassAllocations", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.ClassAllocations", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.ClassAllocations", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.ClassAllocations", "ClassPeriodID", "dbo.ClassPeriods");
            DropForeignKey("dbo.ClassAllocations", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.TeacherAssignments", "AcademicYearID", "dbo.AcademicYears");
            DropIndex("dbo.TeacherAssignments", new[] { "AcademicYearID" });
            DropColumn("dbo.TeacherAssignments", "AcademicYearID");
            AddForeignKey("dbo.TeacherAssignments", "TeacherID", "dbo.Teachers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TeacherAssignments", "SubjectID", "dbo.Subjects", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TeacherAssignments", "GradeID", "dbo.Grades", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "AcademicYearID", "dbo.AcademicYears", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentUsers", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssignments", "SubjectID", "dbo.Subjects", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssignments", "GradeID", "dbo.Grades", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ParentID", "dbo.Parents", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssessments", "SubjectID", "dbo.Subjects", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssessments", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssessments", "GradeID", "dbo.Grades", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssessments", "AssessmentGradesID", "dbo.AssessmentGrades", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAssessments", "AcademicYearID", "dbo.AcademicYears", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Parents", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Parents", "StateID", "dbo.States", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ClassAllocations", "SubjectID", "dbo.Subjects", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ClassAllocations", "RoomID", "dbo.Rooms", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ClassAllocations", "GradeID", "dbo.Grades", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ClassAllocations", "ClassPeriodID", "dbo.ClassPeriods", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ClassAllocations", "AcademicYearID", "dbo.AcademicYears", "ID", cascadeDelete: true);
        }
    }
}
