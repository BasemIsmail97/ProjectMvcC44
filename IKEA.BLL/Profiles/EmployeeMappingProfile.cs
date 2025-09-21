using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Profiles
{
    public class EmployeeMappingProfile: AutoMapper.Profile
    {
        public EmployeeMappingProfile()
        {
            #region EmployeeDto Mapping
            CreateMap<IKEA.DAL.Models.Employees.Employee, IKEA.BLL.DTOS.Employee.EmployeeDto>()
                   .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()))
                   .ForMember(dest => dest.Gender, opt => opt.MapFrom(scr => scr.Gender.ToString()));
            #endregion
            #region EmployeeDetails Mapping

            CreateMap<IKEA.DAL.Models.Employees.Employee, IKEA.BLL.DTOS.Employee.EmployeeDetailsDto>()
                   .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()))
                   .ForMember(dest => dest.Gender, opt => opt.MapFrom(scr => scr.Gender.ToString()));
            #endregion
            #region CreateEmployee Mapping

            CreateMap<IKEA.BLL.DTOS.Employee.CreatedEmployeeDto, IKEA.DAL.Models.Employees.Employee>();

            #endregion
            #region UpdateEmployee Mapping

            CreateMap<IKEA.BLL.DTOS.Employee.UpdatedEmployeeDto, IKEA.DAL.Models.Employees.Employee>().
                ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType.ToString()))
                   .ForMember(dest => dest.Gender, opt => opt.MapFrom(scr => scr.Gender.ToString()));

            #endregion

        }

    }
}
