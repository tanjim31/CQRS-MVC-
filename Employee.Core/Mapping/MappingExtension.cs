using AutoMapper;
using Employee.Model;
using Employee.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Mapping
{
    public  class MappingExtension:Profile
    {
        public MappingExtension()
        {
            CreateMap<VMEmployee, Employees>().ReverseMap()
                .ForMember(x => x.CountryName, x => x.MapFrom(x => x.Country != null ? x.Country.CountryName : " "))
                .ForMember(x => x.StateName, x => x.MapFrom(x => x.State != null ? x.State.StateName : " "));
            //.ForMember(x=> x.StateName, x => x.MapFrom(x => x.State != null ? x.State.StateName : " "));
            CreateMap<VMCountry, Country>().ReverseMap();
            CreateMap<VMState, State>().ReverseMap()
                .ForMember(x=>x.CountryName, x=>x.MapFrom(x=>x.Country !=null? x.Country.CountryName:" ")); //For using countryname on frontend

        }
    }
}
