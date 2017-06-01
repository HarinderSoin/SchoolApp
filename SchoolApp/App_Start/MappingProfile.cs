using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SchoolApp.DTO;
using SchoolApp.Models;

namespace SchoolApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Parent, ParentDTO>();
            CreateMap<ParentDTO, Parent>();
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<SubjectDTO, Subject>();
            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();
            CreateMap<AcademicYear, AcademicYearDTO>();
            CreateMap<AcademicYearDTO, AcademicYear>();
            CreateMap<ClassPeriod, ClassPeriodDTO>();
            CreateMap<ClassPeriodDTO, ClassPeriod>();
            CreateMap<Grade, GradeDTO>();
            CreateMap<GradeDTO, Grade>();
            CreateMap<ClassAllocation, ClassAllocationDTO>();
            CreateMap<ClassAllocationDTO, ClassAllocation>();
            CreateMap<State, StateDTO>();
            CreateMap<StateDTO, State>();
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();
            CreateMap<TeacherAssignment, TeacherAssignmentDTO>();
            CreateMap<TeacherAssignmentDTO, TeacherAssignment>();
            CreateMap<StudentAssignment, StudentAssignmentDTO>();
            CreateMap<StudentAssignmentDTO, StudentAssignment>();




        }
    }
}