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


        public bool ValidateDupicateData(Models.ClassAllocation classAllocation)
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
    }
}