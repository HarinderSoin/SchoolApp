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



        }
    }
}