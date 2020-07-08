using AutoMapper;
using Employees.Core.DTOs;
using Employees.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Providers.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
