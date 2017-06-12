using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.DTO;
using SchoolApp.Models;

namespace SchoolApp.BusinessLogic.ClassAllocation
{
    public class ClassAllocationValidation
    {
        private ApplicationDbContext _context;

        private Models.ClassAllocation _classAllocationRec ;

        public ClassAllocationValidation()
        {
            this._classAllocationRec = new Models.ClassAllocation();
            _context = new ApplicationDbContext();
        }

        public string ValidateClassAllocation(Models.ClassAllocation classAllocation)
        {
            // Validate Subject, Grade, Period and Room for duplicates
            var isClassAllocationValid = ValidateDuplicateAllocations(classAllocation);
            if (!isClassAllocationValid)
                return "Duplicate Class Allocation Found!";

            //Validate Subject and Grades
            var classGradeValid = ValidateDuplicateClassandGrades(classAllocation);
            if (!classGradeValid)
                return "Duplicate Class and Grade Allocation Found!";

            // Validate Subject, Grades and Periods for duplication
            var classGradePeriodValid = ValidateDuplicateClassandGradesandPeriod(classAllocation);
            if (!classGradePeriodValid)
                return "Duplicate Class, Grade and Period Allocation Found!";


            return "All Tests Passed!";

        }
        private bool ValidateDuplicateAllocations(Models.ClassAllocation classAllocation)
        {
            _classAllocationRec = classAllocation;
            string _sql = "select *  from dbo.ClassAllocations where " +
                          "GradeID = " +this._classAllocationRec.GradeID +" and "+ 
                          "SubjectID =" + this._classAllocationRec.SubjectID + " and " +
                          "RoomID =" + this._classAllocationRec.RoomID + " and " +
                          "AcademicYearID =" + this._classAllocationRec.AcademicYearID + " and " +
                          "ClassPeriodID = " + this._classAllocationRec.ClassPeriodID
                           ;
            var _noOfRows = _context.ClassAllocations.SqlQuery(_sql).ToList();

            if (_noOfRows.Any())
                return false;

            return true; 
        }

        private bool ValidateDuplicateClassandGrades(Models.ClassAllocation classAllocation)
        {
            string _sql = "select *  from dbo.ClassAllocations where " +
              "GradeID = " + this._classAllocationRec.GradeID + " and " +
              "SubjectID =" + this._classAllocationRec.SubjectID ;

            var _noOfRows = _context.ClassAllocations.SqlQuery(_sql).ToList();

            if (_noOfRows.Any())
                return false;

            return true;
        }

        private bool ValidateDuplicateClassandGradesandPeriod(Models.ClassAllocation classAllocation)
        {
            string _sql = "select *  from dbo.ClassAllocations where " +
              "GradeID = " + this._classAllocationRec.GradeID + " and " +
              "SubjectID =" + this._classAllocationRec.SubjectID+
               "GradeID =" + this._classAllocationRec.GradeID;

            var _noOfRows = _context.ClassAllocations.SqlQuery(_sql).ToList();

            if (_noOfRows.Any())
                return false;

            return true;
        }
    }
}