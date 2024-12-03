using AutoMapper;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;

namespace UTSTalentHelpDesk.Config
{
    public class UTSProfile : Profile
    {
        //public UTSProfile()
        //{
        //    CreateMap<GenCompany, Company>()
        //        .ForMember(d=>d.en_Id,opt=>opt.MapFrom(s=> CommonLogic.Encrypt(s.Id.ToString())))
        //        .IgnoreAllPropertiesWithAnInaccessibleSetter();

        //    CreateMap<sproc_UTS_GetCompanyDetails_Result, CompanyDetails>();
        //    CreateMap<sproc_UTS_GetContactDetails_Result, ContactDetails>();
        //    CreateMap<GenCompanyContractDetail, CompanyContract>();
        //}
    }
}
